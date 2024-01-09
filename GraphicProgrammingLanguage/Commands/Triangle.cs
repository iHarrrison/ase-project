namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw triangles on the canvas
/// </summary>
public class Triangle : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 1;
    private string SideLength => Arguments[0];
    public Triangle(CommandInfo commandInfo) : base(commandInfo) { }

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
      

        if (!int.TryParse(SideLength, out int sideLength))
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
