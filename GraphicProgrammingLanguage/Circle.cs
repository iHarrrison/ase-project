using System;
using System.Drawing;
using System.Windows.Forms;

public static class Circle
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        if (args.Length < 1)
        {
            MessageBox.Show("The circle command expects one argument (radius).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (int.TryParse(args[0], out int radius))
        {
            // Check to see if the pictureBox.Image is null; if it is, instantiate.
            if (pictureBox.Image == null)
            {
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                // performs the maths necessary to figure out the top-left bounds
                // of the circle required for drawing it after being given the radius
                Pen pen = new Pen(Color.Black);
                int diameter = radius * 2;
                int x = drawingPosition.X - radius;
                int y = drawingPosition.Y - radius;

                g.DrawEllipse(pen, x, y, diameter, diameter);
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
        }
        else
        {
            MessageBox.Show("Invalid radius value for Circle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
