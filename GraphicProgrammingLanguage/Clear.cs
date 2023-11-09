using System;
using System.Drawing;
using System.Windows.Forms;

public static class Clear
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        // Clears the PictureBox

        pictureBox.Image = null;

        MessageBox.Show("Canvas cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
