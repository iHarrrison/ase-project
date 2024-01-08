using System.Data;

namespace GraphicProgrammingLanguage;

using Model;

public static class Parser
{
    public static CommandInfo[] ParseNew(string input)
    {
        List<CommandInfo> result = new();
        string[] lines = input.Split(Constants.NewLine, Constants.ArgumentSplitFlags);
        int lineIndex = 0;
        while (lineIndex < lines.Length)
        {
            result.Add(ParseLineNew(lines, ref lineIndex));
            ++lineIndex;
        }

        return result.ToArray();
    }

    private static CommandInfo ParseLineNew(IReadOnlyList <string> lines, ref int lineIndex)
    {
        string line = lines[lineIndex];
        string command = line.Split(' ', Constants.ArgumentSplitFlags)[0];
        return new CommandInfo { Command = command, Arguments = line[command.Length..].Trim() };
    }

    public static bool TryParseIntExpression(string expression, out int result)
    {
        // Check 1: Constant assignment
        if (int.TryParse(expression, out result))
        {
            return true;
        }

        // Check 2: replace variable tokens with constants (i.e replace someVar with value in variable list)
        // Taken from: https://stackoverflow.com/a/11029886
        try
        {
            string computedExpression = $"{new DataTable().Compute(ConvertToSQLOperands(FindReplaceVariableNames(expression)), "")}".Split('.')[0];
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

    private static string ConvertToSQLOperands(string input) => input.Replace("==", "=").Replace("!=", "<>");
}
