using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the ability to move to a different drawing position on the canvas
/// </summary>
public class Moveto : AbstractCommand
{
    /// <summary>
    /// Executes the moveto command, moving to a given position on the canvas and creating a small dot
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The array of strings containing the x and y coordinates</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 2)
        {
            MessageBox.Show($"The {nameof(Moveto)} command expects two arguments (x and y coordinates)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
        {
            drawingPosition.X = x;
            drawingPosition.Y = y;

            // check to see if the pictureBox.Image is null, if it is, instantiate.
            pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

            // Set the pen color using CanvasPen
            new CanvasPen().Execute(pictureBox, drawingPosition, args);

            // Draw a small circle at the new drawing position
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                const int markerSize = 5;
                g.DrawEllipse(new Pen(drawingPosition.PenColor), x - markerSize / 2, y - markerSize / 2, markerSize, markerSize);
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
            return true;
        }

        MessageBox.Show($"Invalid x or y values for {nameof(Moveto)} command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}
