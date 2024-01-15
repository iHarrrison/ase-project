using System.Data;
using System.Text.RegularExpressions;

namespace GraphicProgrammingLanguage;

using Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/// <summary>
/// Enables the parsing functionality via multiple methods.
/// </summary>
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
    // creates the data table - essentially converts the string to
    // SQL and allows operations to be performed. A bit weird,
    // but it works!
    private static DataTable _dataTable = new();

    /// <summary>
    /// Parses the input string to extract command information and figure out what to do with it.
    /// </summary>
    /// <param name="input">The input string containing commands.</param>
    /// <returns>An array of CommandInfo representing parsed commands.</returns>
    public static CommandInfo[] Parse(string input)
    {
        // List to store parsed CommandInfo objects
        List<CommandInfo> result = new();
       
        // Split input into lines
        string[] lines = input.Split(Constants.NewLine, Constants.ArgumentSplitFlags);

        // Reset line index to 0 so it parses from the first line
        _lineIndex = 0;

        // Parse each line and add the corresponding CommandInfo to the result list
        while (_lineIndex < lines.Length)
        {
            // Get the current line
            string line = lines[_lineIndex];
            // Check if the line starts with a block command
            // If true, parse the entire block. If false, parse just the one line
            result.Add(LineStartsWithStartBlockCommand(line) ? ParseConditionalBlock(lines) : ParseLine(lines));
        }
        return result.ToArray();
    }

    /// <summary>
    /// Parses a single line of code and extracts command information.
    /// </summary>
    /// <param name="lines">The list of lines in the input string.</param>
    /// <returns>A CommandInfo representing the parsed command.</returns>
    private static CommandInfo ParseLine(IReadOnlyList<string> lines)
    {
        string line = lines[_lineIndex++];
        // Check if the line starts with "else "
        if (line.StartsWith($"{StartElseBlockToken} "))
        {
            line = line.Remove(0, StartElseBlockToken.Length).Trim();
        }
        // Extract the command and arguments
        string command = line.Split(' ', Constants.ArgumentSplitFlags)[0];
        return new CommandInfo { Command = command, Arguments = line[command.Length..].Trim() };
    }

    /// <summary>
    /// Parses a conditional block of code and extracts command information.
    /// </summary>
    /// <param name="lines">The list of lines in the input string.</param>
    /// <returns>A CommandInfo representing the parsed command of the conditional block.</returns>
    private static CommandInfo ParseConditionalBlock(IReadOnlyList<string> lines)
    {
        bool commandBranch = true;
        CommandInfo commandInfo = ParseLine(lines);
        
        // Loop through the lines within the conditional block
        while (_lineIndex < lines.Count)
        {
            string line = lines[_lineIndex];
            // Check if the block is ending
            if (LineStartsWithEndBlockCommand(line))
            {
                ++_lineIndex;
                break;
            }
                
            // Check if the block has an "else" statement
            if (line.StartsWith(StartElseBlockToken))
            {
                ++_lineIndex;
                commandBranch = false;
                continue;
            }
            // Determine which branch the line belongs to and parse - essentially flagging.
            if (commandBranch)
            {
                commandInfo.TrueConditionCommandInfos.Add(LineStartsWithStartBlockCommand(line) ? ParseConditionalBlock(lines) : ParseLine(lines));
            }
            else
            {
                commandInfo.FalseConditionCommandInfos.Add(LineStartsWithStartBlockCommand(line) ? ParseConditionalBlock(lines) : ParseLine(lines));
            }
        }
        return commandInfo;
    }

    // Check 1: Constant assignment
    // Check 2: replace variable tokens with constants (i.e replace someVar with value in variable list)
    // Taken from: https://stackoverflow.com/a/11029886
    public static bool TryParseExpression(string expression, out int result) =>
        int.TryParse(expression, out result) || TryParseComputedExpression(expression, out result);

    /// <summary>
    /// Tries to parse a computed expression and any of their operations.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <param name="result">The parsed result if successful, or a -1.</param>
    /// <returns>True if parsing is successful. Anything else and it is false..</returns>
    public static bool TryParseComputedExpression(string expression, out int result)
    {
        // default to -1 in case of any parsing errors
        result = -1;
        try
        {
            // compute the expression via the datatable compute method, and convert the given operands to SQL ones
            string computedExpression = TruncateDecimalToInt($"{_dataTable.Compute(ConvertToSQLOperands(FindReplaceVariableNames(expression)), "")}");
            
            // Attempt to parse the computed expression as an integer
            if (int.TryParse(computedExpression, out result))
            {
                return true;
            }
            // If parsing as an integer fails, try parsing as a boolean
            if (bool.TryParse(computedExpression, out bool boolResult))
            {
                // Convert the result to an integer (1 for true, 0 for false).
                result = Convert.ToInt32(boolResult);
                return true;
            }
        }

        // Error - I need to look at better way of doing this.
        catch (SyntaxErrorException syntaxError)
        {
            MessageBox.Show(syntaxError.Message, "A Syntax Error has occurred, please double check your syntax"); 
        }
        return false;
    }

    // Functionality below allows for nested loops
    // Method to determine the start of a new block
    private static bool LineStartsWithStartBlockCommand(string line) =>
        line.StartsWith(StartIfBlockToken) || line.StartsWith(StartLoopBlockToken) || line.StartsWith(StartMethodBlockToken);

    // Method to determine the end of a new block
    private static bool LineStartsWithEndBlockCommand(string line) =>
        line.StartsWith(EndIfBlockToken) || line.StartsWith(EndLoopBlockToken) || line.StartsWith(EndMethodBlockToken);

    /// <summary>
    /// Finds and replaces variable names in the given expression with their corresponding values.
    /// </summary>
    /// <param name="valueTokens">The expression containing variable names.</param>
    /// <returns>The expression with variable names replaced by their values.</returns>
    private static string FindReplaceVariableNames(string valueTokens)
    {
        // Iterate through each variable in the Variables dictionary
        foreach (string variableName in GlobalDataList.Instance.Variables.Keys)
        {
            int index = valueTokens.IndexOf(variableName, StringComparison.CurrentCulture);
            int nextCharIndex = index + variableName.Length;
            
            // Replace all occurrences of the variable name with its value
            while (index != -1 && (nextCharIndex <= valueTokens.Length || Constants.ReservedNames.Contains(valueTokens[nextCharIndex])))
            {
                // Remove the variable name and insert its value in its place
                valueTokens = valueTokens.Remove(index, variableName.Length).Insert(index, $"{GlobalDataList.Instance.Variables[variableName]}");
                
                // Find the next occurrence of the variable name
                index = valueTokens.IndexOf(variableName, StringComparison.CurrentCulture);
                nextCharIndex = index + variableName.Length;
            }
        }

        return valueTokens;
    }

    // Converts any operands with their sql variants, so the datatable operations work
    private static string ConvertToSQLOperands(string input)
    {
        input = input.Replace("==", " = ").Replace("!=", " <> ").Replace("!", " not ").Replace("&&", " and ").Replace("||", " or ").Replace("  ", " ");
        input = Regex.Replace(input, AdjacentLogicalOperatorPattern, match => match.Value == "0" ? " false " : " true ");
        return input;
    }

   // Truncates any decimal, taking only the first value (ignoring the values post-decimal)
    private static string TruncateDecimalToInt(string input) => input.Split('.')[0];
}