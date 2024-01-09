namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw circles on the canvas
/// </summary>
public class Circle : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Circle command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Gets the radius value from the command arguments.
    /// </summary>
    private string Radius => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Circle(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Circle command, drawing circles on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseExpression(Radius, out int radius))
        {
            return false;
        }

        // Check to see if the pictureBox.Image is null; if it is, instantiate.
        pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            // performs the maths necessary to figure out the top-left bounds
            // of the circle required for drawing it after being given the radius
            int diameter = radius * 2;
            int x = drawingPosition.X - radius;
            int y = drawingPosition.Y - radius;

            if (drawingPosition.FillOn)
            {
                g.FillEllipse(new SolidBrush(drawingPosition.PenColor), x, y, diameter, diameter);
            }
            else
            {
                g.DrawEllipse(new Pen(drawingPosition.PenColor), x, y, diameter, diameter);
            }
        }

        return true;
    }
}
