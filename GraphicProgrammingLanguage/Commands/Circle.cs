namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw circles on the canvas
/// </summary>
public class Circle : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 1;

    public Circle(CommandInfo commandInfo) => Arguments = new[] { commandInfo.Arguments };

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseIntExpression(Arguments[0], out int radius))
        {
            return false;
        }

        // Check to see if the pictureBox.Image is null; if it is, instantiate.
        pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            // performs the maths necessary to figure out the top-left bounds
            // of the circle required for drawing it after being given the radius
            int diameter = radius * 2;
            int x = drawingPosition.X - radius;
            int y = drawingPosition.Y - radius;

            if (drawingPosition.FillOn)
            {
                g.FillEllipse(new SolidBrush(drawingPosition.PenColor), x, y, diameter, diameter);
            }
            else
            {
                g.DrawEllipse(new Pen(drawingPosition.PenColor), x, y, diameter, diameter);
            }
        }

        return true;
    }
}
