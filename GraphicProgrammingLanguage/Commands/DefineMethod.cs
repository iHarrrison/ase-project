namespace GraphicProgrammingLanguage.Commands;

using Factory;
using Model;
using System.Text.RegularExpressions;

public class DefineMethod : AbstractGPLConditionalCommand
{
    private const string MethodNamePattern = @".+?(?=\()";

    private const string ParameterListPattern = @"(?<=\()(.*?)(?=\))";

    public override int ExpectedArgumentsCount => 1;
    public DefineMethod(CommandInfo commandInfo) : base(commandInfo)
    {
        List<string> parsedMethodArguments = new() { GetMethodNameFromDeclaration(commandInfo.Arguments) };
        parsedMethodArguments.AddRange(GetMethodParametersFromDeclaration(commandInfo.Arguments));
        Arguments = parsedMethodArguments.ToArray();
        GlobalDataList.Instance.Methods.Add(Arguments[0], this);
    }

    public override bool IsValid() => Arguments.Length >= ExpectedArgumentsCount;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) =>
        TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition));

    public static string GetMethodNameFromDeclaration(string methodDeclaration) =>
        new Regex(MethodNamePattern).Match(methodDeclaration).Value.ToLower();

    public static IEnumerable<string> GetMethodParametersFromDeclaration(string methodDeclaration) =>
        new Regex(ParameterListPattern).Match(methodDeclaration).Value.Split(',');
}
