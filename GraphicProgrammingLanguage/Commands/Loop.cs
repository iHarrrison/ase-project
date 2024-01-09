namespace GraphicProgrammingLanguage.Commands;

using Factory;
using Model;
public class Loop : AbstractGPLConditionalCommand
{
    public override int ExpectedArgumentsCount => 1;
    private string Condition => Arguments[0];

    public Loop(CommandInfo commandInfo) : base(commandInfo) { }

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        int result;
        while (Parser.TryParseComputedExpression(Condition, out result) && result == 1)
        {
            if (!TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition)))
            {
                return false;
            }
        }
        return result > -1;
    }
}
