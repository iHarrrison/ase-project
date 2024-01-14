namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Represents the functionality to draw triangles on the canvas
/// </summary>
public class Triangle : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Triangle command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Gets the side length value from the command arguments.
    /// </summary>
    private string SideLength => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Triangle(CommandInfo commandInfo) : base(commandInfo) { }

    /// <summary>
    /// Executes the Triangle command, drawing triangles on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {

        if (!Parser.TryParseExpression(SideLength, out int sideLength))
        {
            return false;
        }

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            // Calculate the points of the triangle.
            // point1 is the top, point2 is bottom-left and point3 is bottom-right
            Point point1 = new Point(drawingPosition.X, drawingPosition.Y - sideLength);
            Point point2 = new Point(drawingPosition.X - sideLength / 2, drawingPosition.Y + sideLength / 2);
            Point point3 = new Point(drawingPosition.X + sideLength / 2, drawingPosition.Y + sideLength / 2);

            // Set the fill color if FillOn is true
            if (drawingPosition.FillOn)
            {
                g.FillPolygon(new SolidBrush(drawingPosition.PenColor), new[] { point1, point2, point3 });
            }

            g.DrawPolygon(new Pen(drawingPosition.PenColor), new[] { point1, point2, point3 });
        }

        pictureBox.Refresh(); // Refresh the PictureBox to display the changes

        return true;
    }
}
