namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw lines from one place to another on the canvas
/// </summary>
public class Drawto : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Drawto command.
    /// </summary>
    public override int ExpectedArgumentsCount => 2;

    /// <summary>
    /// Gets the X-coordinate target from the command arguments.
    /// </summary>
    private string XTarget => Arguments[0];

    /// <summary>
    /// Gets the Y-coordinate target from the command arguments.
    /// </summary>
    private string YTarget => Arguments[1];

    /// <summary>
    /// Initializes a new instance of the <see cref="Drawto"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Drawto(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Drawto command, drawing lines from one place to another on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!int.TryParse(XTarget, out int xTarget) || !int.TryParse(YTarget, out int yTarget))
        {
            return false;
        }

        // Draw a line from the current drawing position to the given coordinates.
        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            g.DrawLine(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, xTarget, yTarget);
        }

        // Update the drawing position to the new coordinates
        drawingPosition.X = xTarget;
        drawingPosition.Y = yTarget;

        return true;
    }
}
