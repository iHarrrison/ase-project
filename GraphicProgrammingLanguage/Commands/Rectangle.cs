using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the ability to draw rectangles on the canvas
/// </summary>
public class Rectangle : AbstractCommand
{
    /// <summary>
    /// Executes the Rectangle command to draw a rectangle onto the canvas with the given parameters
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The array of strings containing the width and height</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 2)
        {
            MessageBox.Show("The rectangle command expects two arguments (width and height).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
        {
            // check to see if the pictureBox.Image is null, if it is, instantiate.
            pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

            // Set the pen color using CanvasPen
            new CanvasPen().Execute(pictureBox, drawingPosition, args);

            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                if (drawingPosition.FillOn)
                {
                    g.FillRectangle(new SolidBrush(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
                }
                g.DrawRectangle(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
            return true;
        }

        MessageBox.Show("Invalid width or height values for Rectangle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}
