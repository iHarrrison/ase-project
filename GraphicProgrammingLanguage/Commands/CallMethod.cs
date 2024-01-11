namespace GraphicProgrammingLanguage.Commands;

using Model;
using Utility;

/// <summary>
/// Represents the functionality to call a defined method.
/// </summary>
public class CallMethod : AbstractGPLCommand
{
    /// <summary>
    /// Gets the expected number of arguments for the CallMethod command.
    /// </summary>
    public override int ExpectedArgumentsCount => TargetMethod.Arguments.Length - 1;

    private DefineMethod TargetMethod { get; }
    private static GlobalDataList GlobalDataList => GlobalDataList.Instance;

    private SortedDictionary<string, int> _methodArguments = new(new DescendingKeyLengthComparer());

    /// <summary>
    /// Initializes a new instance of the <see cref="CallMethod"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public CallMethod(CommandInfo commandInfo) : base(commandInfo)
    {
        TargetMethod = GlobalDataList.Methods[commandInfo.Command];
        TrueCommandList = TargetMethod.TrueCommandList;
    }

    /// <summary>
    /// Executes the CallMethod command, calling the efined method and its specified arguments.
    /// </summary>
    /// <param name="pictureBox">The PictureBox where drawing takes place.</param>
    /// <param name="drawingPosition">The current drawing position.</param>
    /// <returns>True if the command execution is successful; otherwise, false.</returns>
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        ParseMethodArguments();
        foreach ((string name, int value) in _methodArguments)
        {
            GlobalDataList.Variables.Add(name, value);
        }

        bool result = TargetMethod.Execute(pictureBox, drawingPosition);

        foreach ((string name, _) in _methodArguments)
        {
            GlobalDataList.Variables.Remove(name);
        }

        return result;
    }


    private void ParseMethodArguments()
    {
        for (var argIndex = 0; argIndex < Arguments.Length; ++argIndex)
        {
            var argument = TargetMethod.Arguments[argIndex + 1];
            if (Parser.TryParseExpression(Arguments[argIndex], out int value))
            {
                _methodArguments[argument] = value;
            }
        }
    }
}
