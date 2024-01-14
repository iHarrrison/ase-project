using System.Text.RegularExpressions;

namespace GraphicProgrammingLanguage.Commands;

using Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/// <summary>
/// Represents the functionality to assign a value to a variable.
/// </summary>
public class AssignVariable : AbstractGPLCommand
{
    // This regex looks for the = operator for assigning a var,
    // but does only if it is not part of the inequality operator. Pretty cool!
    private const string AssignmentOpMatchPattern = @"(?<!=)=(?!=)(?<!!=)";
    private const int VariableNameIndex = 0;
    private const int ValueIndex = 1;

    /// <summary>
    /// Gets the expected number of arguments for the AssignVariable command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="AssignVariable"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public AssignVariable(CommandInfo commandInfo) : base(commandInfo)
    {
        // Split the command arguments using the assignment operator pattern
        Arguments = new Regex(AssignmentOpMatchPattern).Split(commandInfo.Arguments).Select(token => token.Trim()).ToArray();

        // Try to parse the expression on the right-hand side of the assignment
        if (!Parser.TryParseExpression(Arguments[ValueIndex], out int value))
        {
            return;
        }
        // Assign the parsed value to the variable in the global data list
        GlobalDataList.Instance.Variables[Arguments[VariableNameIndex]] = value;
    }

    /// <summary>
    /// Checks whether the AssignVariable command is valid.
    /// </summary>
    /// <returns>True if the command is valid; otherwise, false.</returns>
    public override bool IsValid() => Arguments.Length > ExpectedArgumentsCount;

    /// <summary>
    /// Executes the AssignVariable command.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) => true;
}