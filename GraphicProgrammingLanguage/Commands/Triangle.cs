using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the ability to draw triangles on the canvas
/// </summary>
public class Triangle : AbstractCommand
{
    /// <summary>
    /// Executes the Triangle command to draw a triangle onto the canvas with the given parameters
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The array of strings containing the side length</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 1)
        {
            MessageBox.Show("The triangle command expects one argument (side length)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(args[0], out int sideLength))
        {
            MessageBox.Show("Invalid side length value entered for Triangle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Check to make see if the pictureBox.Image is null; if it is, instantiate
        pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

        // Set the pen color using CanvasPen
        new CanvasPen().Execute(pictureBox, drawingPosition, args);

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
