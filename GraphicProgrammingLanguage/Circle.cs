using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicProgrammingLanguage
{
    public class Circle
    {
        public static void Execute(PictureBox pictureBox, string[] args)
        {
            if (args.Length >= 3)
            {

                // passes in the x and y coordinates and then the radius of the circle. This is temporary, as when I implement the drawing position class it will
                // not use the centreX and centreY (if I have understood my reading correctly...!)
                if (int.TryParse(args[0], out int centreX) && int.TryParse(args[1], out int centreY) && int.TryParse(args[2], out int radius))
                {
                    if (pictureBox.Image == null)
                    {
                        // Initialize the pictureBox.Image if it is null
                        pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                    }

                    using (Graphics g = Graphics.FromImage(pictureBox.Image))
                    {
                        int x = centreX - radius; // Calculates the top-left corner X coordinate
                        int y = centreY - radius; // Calculates the top-left corner Y coordinate

                        g.DrawEllipse(Pens.Black, x, y, radius * 2, radius * 2);
                    }

                    pictureBox.Invalidate(); // Refreshes the pictureBox to show the changes on the canvas.

                }

                else
                {
                    MessageBox.Show("Sorry, it appears you have entered invalid arguments for this command. " +
                        "Please provide valid values to draw your shape.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
