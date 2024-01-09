namespace GraphicProgrammingLanguage.Commands;

using Model;


/// <summary>
/// Enables the ability to reset the drawing position
/// </summary>
public class Reset : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Reset command.
    /// </summary>
    public override int ExpectedArgumentsCount => 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Reset"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Reset(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Reset command, resetting the drawing position to (0, 0).
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        drawingPosition.X = 0;
        drawingPosition.Y = 0;

        MessageBox.Show("Drawing position reset!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
