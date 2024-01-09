namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Handles commands for the pen color for drawing on the canvas
/// </summary>
public class CanvasPen : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the CanvasPen command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;
    
    /// <summary>
    /// Gets the color value from the command arguments.
    /// </summary>
    private string Colour => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="CanvasPen"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public CanvasPen(CommandInfo commandInfo) => Arguments = new[] { commandInfo.Arguments };

    /// <summary>
    /// Executes the CanvasPen command, setting the pen color for drawing on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command is executed successfully; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        drawingPosition.PenColor = Color.FromName(Colour);
        drawingPosition.PenColor = Color.FromName(Colour);
        MessageBox.Show($"Pen color set to {Colour}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
