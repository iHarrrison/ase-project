namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Handles commands for the pen color for drawing on the canvas
/// </summary>
public class CanvasPen : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 1;

    public CanvasPen(params object[] args) => Arguments = args.Cast<string>().ToArray();
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        Color newColour = Color.FromName($"{Arguments[0]}");
        drawingPosition.PenColor = newColour;
        MessageBox.Show($"Pen color set to {newColour.Name}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
