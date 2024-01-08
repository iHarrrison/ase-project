namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the functionality to clear the canvas of any drawings
/// </summary>
public class Clear : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 0;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        pictureBox.Image = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);

        MessageBox.Show("Canvas cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
