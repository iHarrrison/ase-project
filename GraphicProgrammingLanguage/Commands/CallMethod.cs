namespace GraphicProgrammingLanguage.Commands;

using Model;
using Utility;
public class CallMethod : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => TargetMethod.Arguments.Length - 1;

    private DefineMethod TargetMethod { get; }
    private static GlobalDataList GlobalDataList => GlobalDataList.Instance;

    private SortedDictionary<string, int> _methodArguments = new(new DescendingKeyLengthComparer());

    public CallMethod(CommandInfo commandInfo) : base(commandInfo)
    {
        TargetMethod = GlobalDataList.Methods[commandInfo.Command];
        TrueCommandList = TargetMethod.TrueCommandList;
    }

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
