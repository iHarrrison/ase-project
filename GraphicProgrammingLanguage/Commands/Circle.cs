using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the ability to draw circles on the canvas
/// </summary>
public class Circle : AbstractCommand
{
    /// <summary>
    /// Executes the circle drawing command
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The array of strings containing the radius</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 1)
        {
            MessageBox.Show("The circle command expects one argument (radius).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (int.TryParse(args[0], out int radius))
        {
            // Check to see if the pictureBox.Image is null; if it is, instantiate.
            pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

            // Set the pen color using CanvasPen
            new CanvasPen().Execute(pictureBox, drawingPosition, args);

            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                // performs the maths necessary to figure out the top-left bounds
                // of the circle required for drawing it after being given the radius
                int diameter = radius * 2;
                int x = drawingPosition.X - radius;
                int y = drawingPosition.Y - radius;

                g.DrawEllipse(new Pen(drawingPosition.PenColor), x, y, diameter, diameter);

                if (drawingPosition.FillOn)
                {
                    g.FillEllipse(new SolidBrush(drawingPosition.PenColor), x, y, diameter, diameter);
                }
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
        }
        else
        {
            MessageBox.Show("Invalid radius value for Circle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return true;
    }
}
