namespace GraphicProgrammingLanguage.Commands;

using Model;
using System.Text.RegularExpressions;

/// <summary>
/// Represents the functionality to defined a method - this is essentially the command of method.
/// </summary>
public class DefineMethod : AbstractGPLConditionalCommand
{
    private const string MethodNamePattern = @".+?(?=\()";

    private const string ParameterListPattern = @"(?<=\()(.*?)(?=\))";

    /// <summary>
    /// Gets the expected number of arguments for the DefineMethod command.
    /// </summary>
    public override int ExpectedArgumentsCount => 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefineMethod"/> class.
    /// </summary>
    /// <param name="commandInfo">The command information containing arguments.</param>
    public DefineMethod(CommandInfo commandInfo) : base(commandInfo)
    {
        List<string> parsedMethodArguments = new() { GetMethodNameFromDeclaration(commandInfo.Arguments) };
        parsedMethodArguments.AddRange(GetMethodParametersFromDeclaration(commandInfo.Arguments));
        Arguments = parsedMethodArguments.ToArray();
        GlobalDataList.Instance.Methods.Add(Arguments[0], this);
    }

    /// <summary>
    /// Gets the method name from the method declaration.
    /// </summary>
    /// <param name="methodDeclaration">The method declaration string.</param>
    /// <returns>The method name.</returns>
    public static string GetMethodNameFromDeclaration(string methodDeclaration) =>
        new Regex(MethodNamePattern).Match(methodDeclaration).Value.ToLower();

    /// <summary>
    /// Gets the method parameters from the method declaration.
    /// </summary>
    /// <param name="methodDeclaration">The method declaration string.</param>
    /// <returns>The list of method parameters.</returns>
    public static IEnumerable<string> GetMethodParametersFromDeclaration(string methodDeclaration) =>
        new Regex(ParameterListPattern).Match(methodDeclaration).Value.Split(',');

    /// <summary>
    /// Checks if the DefineMethod command is valid.
    /// </summary>
    /// <returns>True if the DefineMethod command is valid; otherwise, false.</returns>
    public override bool IsValid() => Arguments.Length >= ExpectedArgumentsCount;

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition) =>
      TrueCommandList.All(command => command.Execute(pictureBox, drawingPosition));
}
