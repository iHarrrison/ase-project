namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw rectangles on the canvas
/// </summary>
public class Rectangle : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 2;
    private string Width => Arguments[0];
    private string Height => Arguments[1];

    public Rectangle(CommandInfo commandInfo) : base(commandInfo) { }

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!(Parser.TryParseExpression(Width, out int width) && Parser.TryParseExpression(Height, out int height)))
        {
            return false;
        }

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            if (drawingPosition.FillOn)
            {
                g.FillRectangle(new SolidBrush(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
            else
            {
                g.DrawRectangle(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
        }

        return true;
    }
}
