namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Represents the functionality to clear the canvas of any drawings.
/// </summary>
public class Clear : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Clear command.
    /// </summary>
    public override int ExpectedArgumentsCount => 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Clear"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information (unused for Clear).</param>
    public Clear(CommandInfo commandInfo) : base(commandInfo) => Arguments = Array.Empty<string>();

    /// <summary>
    /// Executes the Clear command, clearing the canvas of any drawings.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position (unused for Clear).</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        pictureBox.Image = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);

        MessageBox.Show("Canvas cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return true;
    }
}
