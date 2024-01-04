namespace GraphicProgrammingLanguage.Commands;

public abstract class AbstractCommand
{
    /// <summary>
    /// A Blueprint for the command classes to select from specific colors for the canvas pen
    /// </summary>
    /// <param name="pictureBox">The canvas in which the drawing occurs</param>
    /// <param name="drawingPosition">The current position for drawing, as well as settings (fill/pen color)</param>
    /// <param name="args">The argument containing the pen color</param>
    public abstract bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition, params string[] args);
}