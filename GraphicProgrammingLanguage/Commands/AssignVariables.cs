using System.Text.RegularExpressions;

namespace GraphicProgrammingLanguage.Commands;

using Model;

public class AssignVariable : AbstractGPLCommand
{
    private const string AssignmentOpMatchPattern = @"(?<!=)=(?!=)(?<!!=)";
    private const int VariableNameIndex = 0;
    private const int ValueIndex = 1;

    public override int ExpectedArgumentsCount => 1;

    public AssignVariable(CommandInfo commandInfo) : base(commandInfo)
    {
        Arguments = new Regex(AssignmentOpMatchPattern).Split(commandInfo.Arguments).Select(token => token.Trim()).ToArray();
        if (!Parser.TryParseExpression(Arguments[ValueIndex], out int value))
        {
            return;
        }
        GlobalDataList.Instance.Variables[Arguments[VariableNameIndex]] = value;
    }

    public override bool IsValid() => Arguments.Length > ExpectedArgumentsCount;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) => true;
}