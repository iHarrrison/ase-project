namespace GraphicProgrammingLanguage.Commands;

using Factory;
using Model;

/// <summary>
/// Represents and enables the functionality of a loop command.
/// </summary>
public class Loop : AbstractGPLConditionalCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Loop command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Gets the condition expression for the loop.
    /// </summary>
    private string Condition => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="Loop"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Loop(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Loop command, repeating the enclosed commands based on the specified condition.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the loop executes successfully; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        int result;
        // Continue the loop while the condition is true
        while (Parser.TryParseComputedExpression(Condition, out result) && result == 1)
        {
            // Execute all commands within the loop
            if (!TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition)))
            {
                return false;
            }
        }
        // Return true if the loop condition was valid, otherwise return false
        return result > -1;
    }
}
