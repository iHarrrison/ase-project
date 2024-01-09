namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Represents a command to reassign a value to a variable in the Graphic Programming Language (GPL) application.
/// </summary>
public class ReassignVariable : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the ReassignVariable command.
    /// </summary>
    public override int ExpectedArgumentsCount => 2;

    /// <summary>
    /// Gets the name of the variable to be reassigned.
    /// </summary>
    private string VariableName => Arguments[0];

    // <summary>
    /// Gets the expression to be assigned to the variable.
    /// </summary>
    private string Expression => Arguments[1];

    /// <summary>
    /// Initializes a new instance of the <see cref="ReassignVariable"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public ReassignVariable(CommandInfo commandInfo) : base(commandInfo) =>
        Arguments = new[] { commandInfo.Command, commandInfo.Arguments.Replace("=", "") };

    /// <summary>
    /// Executes the ReassignVariable command, reassigning a value to a variable.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        var variables = GlobalDataList.Instance.Variables;
        if (Parser.TryParseExpression(Expression, out int result))
        {
            variables[VariableName] = result;
            return true;
        }
        return false;
    }
}