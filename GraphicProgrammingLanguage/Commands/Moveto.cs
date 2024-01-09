namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to move to a different drawing position on the canvas
/// </summary>
public class Moveto : AbstractGPLCommand
{
    private const int MarkerSize = 5;
    public override int ExpectedArgumentsCount => 2;
    private string XPos => Arguments[0];
    private string YPos => Arguments[1];

    private int _xPosition;
    private int _yPosition;

    public Moveto(CommandInfo commandInfo) : base(commandInfo) { }

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!int.TryParse(XPos, out int xPos) || !int.TryParse(YPos, out int yPos))
        {
            return false;
        }

        _xPosition = xPos;
        _yPosition = yPos;

        drawingPosition.X = _xPosition;
        drawingPosition.Y = _yPosition;

        DrawCursor(pictureBox, drawingPosition);

        return true;
    }

    private void DrawCursor(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        // Draw a small circle at the new drawing position
        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            g.DrawEllipse(new Pen(drawingPosition.PenColor), _xPosition - MarkerSize / 2, _yPosition - MarkerSize / 2, MarkerSize, MarkerSize);
        }
    }

}
