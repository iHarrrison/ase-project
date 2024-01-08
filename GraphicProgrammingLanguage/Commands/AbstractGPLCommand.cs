namespace GraphicProgrammingLanguage.Commands;

public interface IGPLCommand
{
    public int ExpectedArgumentsCount { get; }
    public string[] Arguments { get; }

    bool IsValid();
    bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition);
}

public abstract class AbstractGPLCommand : IGPLCommand
{
    public abstract int ExpectedArgumentsCount { get; }
    public string[] Arguments { get; init; }

    protected AbstractGPLCommand(params object[] args) => Arguments = Array.Empty<string>();

    public virtual bool IsValid() => Arguments.Length == ExpectedArgumentsCount;

    public abstract bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition);
}