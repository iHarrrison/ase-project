namespace GraphicProgrammingLanguage.Commands;

public interface IGPLCommand
{
    int ExpectedArgumentsCount { get; }
    string[] Arguments { get; }

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

public abstract class AbstractGPLConditionalCommand : AbstractGPLCommand
{
    public IGPLCommand[] TrueCommandList { get; protected set; }
    public IGPLCommand[] FalseCommandList { get; protected set; }

    protected AbstractGPLConditionalCommand()
    {
        TrueCommandList = Array.Empty<IGPLCommand>();
        FalseCommandList = Array.Empty<IGPLCommand>();
    }
}