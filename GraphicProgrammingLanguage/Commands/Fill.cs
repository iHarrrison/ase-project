namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to toggle filling when drawing shapes on the canvas.
/// </summary>
/// 
public class Fill : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the Fill command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Gets whether filling is turned on or off from the command arguments (1, 0, True, False).
    /// </summary>
    private string IsOn => Arguments[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="Fill"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public Fill(CommandInfo commandInfo) => Arguments = new[] { commandInfo.Arguments };

    /// <summary>
    /// Executes the Fill command, toggling the fill option when drawing shapes on the canvas.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseExpression(IsOn, out int isOn))
        {
            return false;
        }
        drawingPosition.FillOn = Convert.ToBoolean(isOn);
        return true;
    }
}
