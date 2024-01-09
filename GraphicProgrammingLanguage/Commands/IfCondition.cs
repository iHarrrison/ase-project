namespace GraphicProgrammingLanguage.Commands;

using Model;

public class IfCondition : AbstractGPLConditionalCommand
{
    public override int ExpectedArgumentsCount => 1;


    private string Condition => Arguments[0];


    public IfCondition(CommandInfo commandInfo) : base(commandInfo) { }
    
    
    public override bool IsValid() => Arguments.Length >= ExpectedArgumentsCount;

    
    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) =>
        Parser.TryParseComputedExpression(Condition, out int result) && result > -1 &&
        result == 0 ? FalseCommandList.All(command => command.Execute(pictureBox, drawingPosition))
                    : TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition));
}