using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Enables the functionality to clear the canvas of any drawings
/// </summary>
public class Clear : AbstractCommand
{
    /// <summary>
    /// Executes the clearing of the canvas
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="args"></param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        // Clears the PictureBox
        pictureBox.Image = null;

        MessageBox.Show("Canvas cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }
}
