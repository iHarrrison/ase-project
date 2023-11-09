using System;
using System.Drawing;
using System.Windows.Forms;

public static class Triangle
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        if (args.Length < 1)
        {
            MessageBox.Show("The triangle command expects one argument (side length)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (int.TryParse(args[0], out int sideLength))

        {   // Check to make see if the pictureBox.Image is null; if it is, instantiate
            if (pictureBox.Image == null)
            {
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

            }

            // Set the pen color using CanvasPen
            CanvasPen.Execute(pictureBox, args, drawingPosition);

            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen pen = new Pen(drawingPosition.PenColor);
                int halfSide = sideLength / 2;

                // Calculate the points of the triangle, determining the coordinates of each vertex.

                // Point 1 is at the top of the triangle
                Point point1 = new Point(drawingPosition.X, drawingPosition.Y - sideLength);
                // Point 2 is at the bottom-left of the triangle
                Point point2 = new Point(drawingPosition.X - halfSide, drawingPosition.Y + halfSide);
                // Point 3 is at the bottom-right of the triangle
                Point point3 = new Point(drawingPosition.X + halfSide, drawingPosition.Y + halfSide);
                
                // Draw the three lines to connect the points together, making the triangle.
                g.DrawLine(pen, point1, point2);
                g.DrawLine(pen, point2, point3);
                g.DrawLine(pen, point3, point1);
            }

            pictureBox.Refresh(); // Refresh the PictureBox to display the changes
        }
        else
        {
            MessageBox.Show("Invalid side length value entered for Triangle command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}