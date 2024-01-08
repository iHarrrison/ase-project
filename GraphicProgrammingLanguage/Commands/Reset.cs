namespace GraphicProgrammingLanguage.Commands;

using Model;


/// <summary>
/// Enables the ability to reset the drawing position
/// </summary>
public class Reset : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 0;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        drawingPosition.X = 0;
        drawingPosition.Y = 0;

        MessageBox.Show("Drawing position reset!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
