// Drawto.cs
using System;
using System.Drawing;
using System.Windows.Forms;

public static class Drawto
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        if (args.Length < 2)
        {
            MessageBox.Show("Drawto command expects two arguments (x and y).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
        {
            // Check to see if the pictureBox.Image is null; if it is, instantiate
            if (pictureBox.Image == null)
            {
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            // Set the pen color using CanvasPen
            CanvasPen.Execute(pictureBox, args, drawingPosition);

            // Draw a line from the current drawing position to the given coordinates.
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen pen = new Pen(drawingPosition.PenColor);
                g.DrawLine(pen, drawingPosition.X, drawingPosition.Y, x, y);
            }

            // Update the drawing position to the new coordinates
            drawingPosition.X = x;
            drawingPosition.Y = y;

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
        }
        else
        {
            MessageBox.Show("Invalid x or y values for Drawto command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
