using System.Data;
using System.Text.RegularExpressions;

namespace GraphicProgrammingLanguage;

using Model;

public static class Parser
{
    private const string AdjacentLogicalOperatorPattern = @"(.?(1|0)(?= and| or))|((?<=and |or |not ).?(1|0))";
    // Conditonal Block Tokens
    private const string StartIfBlockToken = "if";
    private const string StartElseBlockToken = "else";
    private const string EndIfBlockToken = "endif";
    // Loop Block Tokens
    private const string StartLoopBlockToken = "loop";
    private const string EndLoopBlockToken = "endloop";
    // Method Block Tokens
    private const string StartMethodBlockToken = "method";
    private const string EndMethodBlockToken = "endmethod";

    private static int _lineIndex;
    private static DataTable _dataTable = new();

    public static CommandInfo[] Parse(string input)
    {
        List<CommandInfo> result = new();
        string[] lines = input.Split(Constants.NewLine, Constants.ArgumentSplitFlags);
        _lineIndex = 0;
        while (_lineIndex < lines.Length)
        {
            string line = lines[_lineIndex];
            if (line.StartsWith(StartIfBlockToken) || line.StartsWith(StartLoopBlockToken) || line.StartsWith(StartMethodBlockToken))
            {
                result.Add(ParseConditionalBlock(lines));
            }
            else
            {
                result.Add(ParseLine(lines));
            }
        }
        return result.ToArray();
    }

    private static CommandInfo ParseLine(IReadOnlyList<string> lines)
    {
        string line = lines[_lineIndex++];
        if (line.StartsWith($"{StartElseBlockToken} "))
        {
            line = line.Remove(0, StartElseBlockToken.Length).Trim();
        }
        string command = line.Split(' ', Constants.ArgumentSplitFlags)[0];
        return new CommandInfo { Command = command, Arguments = line[command.Length..].Trim() };
    }

    private static CommandInfo ParseConditionalBlock(IReadOnlyList<string> lines)
    {
        bool commandBranch = true;
        CommandInfo commandInfo = ParseLine(lines);

        while (_lineIndex < lines.Count)
        {
            string line = lines[_lineIndex];
            if (line.StartsWith(EndIfBlockToken) || line.StartsWith(EndLoopBlockToken) || line.StartsWith(EndMethodBlockToken))
            {
                ++_lineIndex;
                break;
            }
            if (line.StartsWith(StartElseBlockToken))
            {
                ++_lineIndex;
                commandBranch = false;
                continue;
            }
            if (commandBranch)
            {
                commandInfo.TrueConditionCommandInfos.Add(line.StartsWith(StartIfBlockToken) ? ParseConditionalBlock(lines) : ParseLine(lines));
            }
            else
            {
                commandInfo.FalseConditionCommandInfos.Add(line.StartsWith(StartIfBlockToken) ? ParseConditionalBlock(lines) : ParseLine(lines));
            }
        }
        return commandInfo;
    }

    // Check 1: Constant assignment
    // Check 2: replace variable tokens with constants (i.e replace someVar with value in variable list)
    // Taken from: https://stackoverflow.com/a/11029886
    public static bool TryParseExpression(string expression, out int result) =>
        int.TryParse(expression, out result) || TryParseComputedExpression(expression, out result);

    public static bool TryParseComputedExpression(string expression, out int result)
    {
        result = -1;
        try
        {
            string computedExpression = TruncateDecimalToInt($"{_dataTable.Compute(ConvertToSQLOperands(FindReplaceVariableNames(expression)), "")}");
            if (int.TryParse(computedExpression, out result))
            {
                return true;
            }
            if (bool.TryParse(computedExpression, out bool boolResult))
            {
                result = Convert.ToInt32(boolResult);
                return true;
            }
        }

        // Error - I need to look at better way of doing this
        catch (SyntaxErrorException syntaxError)
        {
            MessageBox.Show(syntaxError.Message, "A Syntax Error has occurred, please double check your syntax"); 
        }
        return false;
    }

    private static string FindReplaceVariableNames(string valueTokens)
    {
        foreach (string variableName in GlobalDataList.Instance.Variables.Keys)
        {
            int index = valueTokens.IndexOf(variableName, StringComparison.CurrentCulture);
            int nextCharIndex = index + variableName.Length;
            while (index != -1 && (nextCharIndex <= valueTokens.Length || Constants.ReservedNames.Contains(valueTokens[nextCharIndex])))
            {
                valueTokens = valueTokens.Remove(index, variableName.Length).Insert(index, $"{GlobalDataList.Instance.Variables[variableName]}");
                index = valueTokens.IndexOf(variableName, StringComparison.CurrentCulture);
                nextCharIndex = index + variableName.Length;
            }
        }

        return valueTokens;
    }

    private static string ConvertToSQLOperands(string input)
    {
        input = input.Replace("==", " = ").Replace("!=", " <> ").Replace("!", " not ").Replace("&&", " and ").Replace("||", " or ").Replace("  ", " ");
        input = Regex.Replace(input, AdjacentLogicalOperatorPattern, match => match.Value == "0" ? " false " : " true ");
        return input;
    }

    private static string TruncateDecimalToInt(string input) => input.Split('.')[0];
}