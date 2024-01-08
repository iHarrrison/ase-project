using System.Reflection;
using System.Text.RegularExpressions;

namespace GraphicProgrammingLanguage.Commands;

using Model;

public class AssignVariable : AbstractGPLCommand
{
    private const string AssignmentOpMatchPattern = @"(?<!=)=(?!=)(?<!!=)";
    private const int VariableNameIndex = 0;
    private const int ValueIndex = 1;

    public override int ExpectedArgumentsCount => 1;

    public AssignVariable(params object[] args) =>
        Arguments = new Regex(AssignmentOpMatchPattern).Split($"{args[0]}").Select(token => token.Trim()).ToArray();

    public override bool IsValid() => Arguments.Length > ExpectedArgumentsCount;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseIntExpression(Arguments[ValueIndex], out int value))
        {
            return false;
        }
        GlobalDataList.Instance.Variables[Arguments[VariableNameIndex]] = value;
        return true;
    }
}