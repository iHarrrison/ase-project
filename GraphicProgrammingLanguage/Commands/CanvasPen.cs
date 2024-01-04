using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Handles commands for the pen color for drawing on the canvas
/// </summary>
public class CanvasPen : AbstractCommand
{
    private Color DefaultColor => Color.Black;

    /// <summary>
    /// Executes the pen color command to select from specific colors for the canvas pen
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args">The argument containing the pen color</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (!args.Any())
        {
            MessageBox.Show("Pen command expects one argument (colour).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        try
        {
            drawingPosition.PenColor = DefaultColor;
        }
        catch
        {
            Console.WriteLine("Invalid color value for Pen command.");
            return false;
        }

        MessageBox.Show($"Pen color set to {args[0].ToLower()}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
