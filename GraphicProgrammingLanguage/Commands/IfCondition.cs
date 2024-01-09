namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Represents and enables a conditional command that executes different sets of commands based on a specified condition.
/// </summary>

public class IfCondition : AbstractGPLConditionalCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the IfCondition command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Gets the condition expression from the command arguments.
    /// </summary>
    private string Condition => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="IfCondition"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public IfCondition(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Checks if the IfCondition command is valid by ensuring it has the expected number of arguments.
    /// </summary>
    /// <returns>True if the command is valid; otherwise, false.</returns>
    public override bool IsValid() => Arguments.Length >= ExpectedArgumentsCount;

    /// <summary>
    /// Executes the IfCondition command, evaluating the condition expression and executing the appropriate set of commands.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) =>
        Parser.TryParseComputedExpression(Condition, out int result) && result > -1 &&
        result == 0 ? FalseCommandList.All(command => command.Execute(pictureBox, drawingPosition))
                    : TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition));
}