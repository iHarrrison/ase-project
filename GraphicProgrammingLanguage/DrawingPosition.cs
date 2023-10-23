using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicProgrammingLanguage
{
    public class DrawingPosition
    {
        public int x;
        public int y;

        // allows the initial drawing position to be set
        public DrawingPosition(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
        }

        // passes in new x and y coordinates to move the drawing position to a specified location.
        public void MoveTo(int newX,  int newY)
        {
            x = newX;
            y = newY;
        }
    }
}
