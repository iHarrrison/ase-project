namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw lines from one place to another on the canvas
/// </summary>
public class Drawto : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 2;

    public Drawto(CommandInfo commandInfo) => Arguments = commandInfo.Arguments.Split(',', Constants.ArgumentSplitFlags);

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!int.TryParse($"{Arguments[0]}", out int xTarget) || !int.TryParse($"{Arguments[1]}", out int yTarget))
        {
            return false;
        }

        // Draw a line from the current drawing position to the given coordinates.
        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            g.DrawLine(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, xTarget, yTarget);
        }

        // Update the drawing position to the new coordinates
        drawingPosition.X = xTarget;
        drawingPosition.Y = yTarget;

        return true;
    }
}
