namespace GraphicProgrammingLanguage.Commands;

using Factory;
using Model;
using System.Windows.Forms;

public class IfCondition : AbstractGPLConditionalCommand
{
    public override int ExpectedArgumentsCount => 1;

    public IfCondition(CommandInfo commandInfo)
    {
        Arguments = new[] { commandInfo.Arguments };
        TrueCommandList = CommandFactory.CreateCommandListNew(commandInfo.TrueConditionCommandInfos.ToArray());
        FalseCommandList = CommandFactory.CreateCommandListNew(commandInfo.FalseConditionCommandInfos.ToArray());
    }
    public override bool IsValid() => Arguments.Length >= ExpectedArgumentsCount;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) =>
        Parser.TryParseComputedExpression(Arguments[0], out int result) && result > -1 &&
        result == 0 ? FalseCommandList.All(command => command.Execute(pictureBox, drawingPosition))
                    : TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition));
}