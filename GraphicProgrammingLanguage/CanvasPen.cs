using System;
using System.Drawing;
using System.Windows.Forms;

public static class CanvasPen
{
    public static void Execute(PictureBox pictureBox, string[] args, DrawingPosition drawingPosition)
    {
        if (args.Length < 1)
        {
            MessageBox.Show("Pen command expects one argument (colour).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // the argument is the color
        string colorArg = args[0].ToLower();

        // Define some standard colors for pen
        Color penColor;
        switch (colorArg)
        {
            case "black":
                penColor = Color.Black;
                break;

            case "red":
                penColor = Color.Red;
                break;

            case "blue":
                penColor = Color.Blue;
                break;

            case "green":
                penColor = Color.Green;
                break;

            case "yellow":
                penColor = Color.Yellow;
                break;
            // a bit of a workaround to stop invalid error prompts. Need to investigate further.
            default:
                Console.WriteLine("Invalid color value for Pen command.");
                return;
        }

        // Set the pen color
        drawingPosition.PenColor = penColor;

        MessageBox.Show($"Pen color set to {colorArg}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
