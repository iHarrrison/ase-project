namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to move to a different drawing position on the canvas
/// </summary>
public class Moveto : AbstractGPLCommand
{
    /// <summary>
    /// Sets the marker size for giving some visual feedback as to where on the canvas you have moved to             .
    /// </summary>
    private const int MarkerSize = 5;

    /// <summary>
    /// Gets the expected number of arguments for the Moveto command.
    /// </summary>
    public override int ExpectedArgumentsCount => 2;

    /// <summary>
    /// Gets the X-coordinate value from the command arguments.
    /// </summary>
    private string XPos => Arguments[0];

    /// <summary>
    /// Gets the Y-coordinate value from the command arguments.
    /// </summary>
    private string YPos => Arguments[1];

    private int _xPosition;
    private int _yPosition;

    /// <summary>
    /// Initializes a new instance of the <see cref="Moveto"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Moveto(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Moveto command, moving to a different drawing position on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseExpression(XPos, out int xPos) || !Parser.TryParseExpression(YPos, out int yPos))
        {
            return false;
        }

        _xPosition = xPos;
        _yPosition = yPos;

        drawingPosition.X = _xPosition;
        drawingPosition.Y = _yPosition;

        DrawCursor(pictureBox, drawingPosition);

        return true;
    }

    private void DrawCursor(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        // Draw a small circle at the new drawing position
        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            g.DrawEllipse(new Pen(drawingPosition.PenColor), _xPosition - MarkerSize / 2, _yPosition - MarkerSize / 2, MarkerSize, MarkerSize);
        }
    }

}
