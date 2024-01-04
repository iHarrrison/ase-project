using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the ability to draw lines from one place to another on the canvas
/// </summary>
public class Drawto : AbstractCommand
{
    /// <summary>
    /// Executes the drawto command, drawing a line from one coordinate to another
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The array of strings containing the x and y coordinates</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 2)
        {
            MessageBox.Show("Drawto command expects two arguments (x and y).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
        {
            // Check to see if the pictureBox.Image is null; if it is, instantiate
            pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

            // Set the pen color using CanvasPen
            new CanvasPen().Execute(pictureBox, drawingPosition, args);

            // Draw a line from the current drawing position to the given coordinates.
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, x, y);
            }

            // Update the drawing position to the new coordinates
            drawingPosition.X = x;
            drawingPosition.Y = y;

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes

            return true;
        }

        MessageBox.Show("Invalid x or y values for Drawto command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}
