using GraphicProgrammingLanguage.Commands;

public class Fill : AbstractCommand
{
    /// <summary>
    /// Sets the fill option to either true or not true for the drawing position
    /// </summary>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    /// <param name="args">An array of string arguments to set the fill to on or off</param>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args)
    {
        if (args.Length != 1)
        {
            MessageBox.Show("The fill command expects one argument (on/off)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        switch (args[0].ToLower())
        {
            case "on":
                drawingPosition.FillOn = true;
                break;
            case "off":
                drawingPosition.FillOn = false;
                break;
            default:
                MessageBox.Show("Invalid argument for Fill command (use 'on' or 'off').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }

        return true;
    }
}
