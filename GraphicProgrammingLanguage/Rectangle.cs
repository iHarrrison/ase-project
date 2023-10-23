using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicProgrammingLanguage
{
    public class Rectangle
    {
        public static void Execute(PictureBox pictureBox, string[] args)
        {
            if (args.Length >= 2)

                // Look for string arguments for x and y values.
            {
                if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
                {
                    int x = 0;
                    int y = 0;

                    if (pictureBox.Image == null)
                    {
                        // Initialize the PictureBox.Image if it's null, stopping errors.
                        pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                    }

                    using (Graphics g = Graphics.FromImage(pictureBox.Image))
                        // For now, just accepts black pen. This will be changed at a later date.
                    {
                        g.DrawRectangle(Pens.Black, x, y, width, height); 
                    }

                    pictureBox.Invalidate(); // Refreshes the PictureBox to see the changes.
                }
                else
                {
                    // Handles parsing errors via a windows message box.
                    // Plan is to make this a separate class and just call a function as opposed to reusing code for
                    // every shape...
                    MessageBox.Show("Sorry, it appears you have entered invalid arguments for this command. " +
                        "Please provide valid values to draw your shape.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

