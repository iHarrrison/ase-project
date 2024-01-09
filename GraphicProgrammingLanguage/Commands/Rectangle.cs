namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw rectangles on the canvas
/// </summary>
public class Rectangle : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Rectangle command.
    /// </summary>
    public override int ExpectedArgumentsCount => 2;

    /// <summary>
    /// Gets the width value from the command arguments.
    /// </summary>
    private string Width => Arguments[0];

    /// <summary>
    /// Gets the height value from the command arguments.
    /// </summary>
    private string Height => Arguments[1];

    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Rectangle(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Rectangle command, drawing rectangles on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!(Parser.TryParseExpression(Width, out int width) && Parser.TryParseExpression(Height, out int height)))
        {
            return false;
        }

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            if (drawingPosition.FillOn)
            {
                g.FillRectangle(new SolidBrush(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
            else
            {
                g.DrawRectangle(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
        }

        return true;
    }
}
