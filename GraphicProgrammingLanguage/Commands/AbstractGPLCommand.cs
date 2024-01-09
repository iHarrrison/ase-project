using GraphicProgrammingLanguage.Model;

namespace GraphicProgrammingLanguage.Commands;

/// <summary>
/// Represents the interface for a Graphic Programming Language (GPL) command.
/// </summary>
public interface IGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the command.
    /// </summary>
    int ExpectedArgumentsCount { get; }

    /// <summary>
    /// Gets the arguments provided for the command.
    /// </summary>
    string[] Arguments { get; }

    /// <summary>
    /// Checks whether the command is valid based on the provided arguments.
    /// </summary>
    /// <returns>True if the command is valid; otherwise, false.</returns>
    bool IsValid();

    // <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where the command executes.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition);
}

/// <summary>
/// Represents an abstract implementation of the IGPLCommand interface.
/// </summary>
public abstract class AbstractGPLCommand : IGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the command.
    /// </summary>
    public abstract int ExpectedArgumentsCount { get; }

    /// <summary>
    /// Gets or sets the arguments provided for the command.
    /// </summary>
    public string[] Arguments { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractGPLCommand"/> class.
    /// </summary>
    /// <param name="args">The arguments for the command.</param>
    protected AbstractGPLCommand(params object[] args) => Arguments = Array.Empty<string>();

    /// <summary>
    /// Checks whether the command is valid based on the provided arguments.
    /// </summary>
    /// <returns>True if the command is valid; otherwise, false.</returns>
    public virtual bool IsValid() => Arguments.Length == ExpectedArgumentsCount;

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where the command executes.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public abstract bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition);
}

/// <summary>
/// Represents an abstract implementation of a conditional GPL command.
/// </summary>
public abstract class AbstractGPLConditionalCommand : AbstractGPLCommand
{
    /// <summary>
    /// Gets or sets the list of commands to execute if the condition is true.
    /// </summary>
    public IGPLCommand[] TrueCommandList { get; protected set; }

    /// <summary>
    /// Gets or sets the list of commands to execute if the condition is false.
    /// </summary>
    public IGPLCommand[] FalseCommandList { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractGPLConditionalCommand"/> class.
    /// </summary>
    protected AbstractGPLConditionalCommand(CommandInfo commandInfo) : base(commandInfo)
    {
        TrueCommandList = Array.Empty<IGPLCommand>();
        FalseCommandList = Array.Empty<IGPLCommand>();
    }
}