namespace GraphicProgrammingLanguage.Commands;

using Model;

public class ReassignVariable : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 2;
    private string VariableName => Arguments[0];
    private string Expression => Arguments[1];

    public ReassignVariable(CommandInfo commandInfo) : base(commandInfo) =>
        Arguments = new[] { commandInfo.Command, commandInfo.Arguments.Replace("=", "") };

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        var variables = GlobalDataList.Instance.Variables;
        if (Parser.TryParseExpression(Expression, out int result))
        {
            variables[VariableName] = result;
            return true;
        }
        return false;
    }
}