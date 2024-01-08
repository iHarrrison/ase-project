using System.Data;

namespace GraphicProgrammingLanguage;

using Model;
using System.Text.RegularExpressions;

public static class Parser
{
    // Sets up the conditional keywords, along with REGex to go over and find the operators
    private const string AdjacentLogicalOperatorPattern = @"(.?(1|0)(?= and| or))|((?<=and |or |not ).?(1|0))";
    private const string StartIfBlockToken = "if";
    private const string StartElseBlockTokens = "else";
    private const string EndIfBlockToken = "endif";
    public static CommandInfo[] Parse(string input)
    {
        List<CommandInfo> result = new();
        string[] lines = input.Split(Constants.NewLine, Constants.ArgumentSplitFlags);
        int lineIndex = 0;
        while (lineIndex < lines.Length)
        {
            string line = lines[lineIndex];
            result.Add(line.StartsWith(StartIfBlockToken) ? ParseIfBlock(lines, ref lineIndex) : ParseLine(lines, ref lineIndex));
        }
        return result.ToArray();
    }

    private static CommandInfo ParseLine(IReadOnlyList<string> lines, ref int lineIndex)
    {
        string line = lines[lineIndex++];
        if (line.StartsWith($"{StartElseBlockTokens} "))
        {
            line = line.Remove(0, StartElseBlockTokens.Length).Trim();
        }
        string command = line.Split(' ', Constants.ArgumentSplitFlags)[0];
        return new CommandInfo { Command = command, Arguments = line[command.Length..].Trim() };
    }

    private static CommandInfo ParseIfBlock(IReadOnlyList<string> lines, ref int lineIndex)
    {
        CommandInfo ifCommandInfo = ParseLine(lines, ref lineIndex);
        bool commandBranch = true;
        while (lineIndex < lines.Count)
        {
            string line = lines[lineIndex];
            if (line.StartsWith(StartElseBlockTokens))
            {
                commandBranch = false;
                if (line.Contains(StartIfBlockToken))
                {
                    ifCommandInfo.FalseConditionCommandInfos.Add(ParseIfBlock(lines, ref lineIndex));
                }
                ++lineIndex;
                continue;
            }
            if (line.StartsWith(EndIfBlockToken))
            {
                ++lineIndex;
                break;
            }
            if (commandBranch)
            {
                ifCommandInfo.TrueConditionCommandInfos.Add(ParseLine(lines, ref lineIndex));
            }
            else
            {
                ifCommandInfo.FalseConditionCommandInfos.Add(ParseLine(lines, ref lineIndex));
            }
        }

        return ifCommandInfo;
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
            string computedExpression = TruncateDecimalToInt($"{new DataTable().Compute(ConvertToSQLOperands(FindReplaceVariableNames(expression)), "")}");
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
        catch (SyntaxErrorException syntaxError)
        {
            MessageBox.Show(syntaxError.Message, "An Error has Occurred"); 
        }
        return false;
    }

    private static string FindReplaceVariableNames(string valueTokens)
    {
        foreach (string variableName in GlobalDataList.Instance.Variables.Keys)
        {
            int index = valueTokens.IndexOf(variableName, StringComparison.CurrentCulture);
            int nextCharIndex = index + variableName.Length;
            while (index != -1 && (nextCharIndex >= valueTokens.Length || Constants.ReservedNames.Contains(valueTokens[nextCharIndex])))
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
