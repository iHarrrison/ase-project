namespace GraphicProgrammingLanguage.Commands;

using Factory;
using Model;
public class Method : AbstractGPLConditionalCommand
{
    public Method(CommandInfo commandInfo) : base(commandInfo)
    {
    }

    public override int ExpectedArgumentsCount => throw new NotImplementedException();

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        throw new NotImplementedException();
    }
}
