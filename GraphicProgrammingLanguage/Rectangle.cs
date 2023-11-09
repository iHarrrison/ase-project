using System;
using System.Drawing;
using System.Windows.Forms;

public static class Rectangle
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        if (args.Length < 2)
        {
            MessageBox.Show("Rectangle command requires at least two arguments (width and height).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
        {
            // check to make sure the pictureBox.Image is null, if it is instantiate.
            if (pictureBox.Image == null)
            {
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen pen = new Pen(Color.Black);
                g.DrawRectangle(pen, drawingPosition.X, drawingPosition.Y, width, height);
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
        }
        else
        {
            MessageBox.Show("Invalid width or height values for Rectangle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
