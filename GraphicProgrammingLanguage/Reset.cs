using System;
using System.Drawing;
using System.Windows.Forms;

public static class Reset
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        // Reset the drawing position
        drawingPosition.X = 0;
        drawingPosition.Y = 0;

        MessageBox.Show("Drawing position reset!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
