namespace GraphicProgrammingLanguage.Factory;

using Commands;
using Model;

/// <summary>
/// Factory class responsible for creating instances of commands based on provided command information.
/// </summary>
public static class CommandFactory
{
    // dictionary containing all the defined commands expected. They have to be 
    // defined here in order to work (essentially, if the command keyword is entered
    // it pairs up with the class.
    private static readonly Dictionary<string, Type> _commandTokenMap = new()
    {
        { "rectangle", typeof(Rectangle) },
        { "circle", typeof(Circle) },
        { "triangle", typeof(Triangle) },
        { "moveto", typeof(Moveto) },
        { "drawto", typeof(Drawto) },
        { "pen", typeof(CanvasPen) },
        { "fill", typeof(Fill) },
        { "clear", typeof(Clear) },
        { "reset", typeof(Reset) },
        { "var", typeof(AssignVariable) },
        { "if", typeof(IfCondition) },
        {"loop", typeof(Loop) },
    };

    /// <summary>
    /// Creates a list of commands based on an array of command information.
    /// </summary>
    /// <param name="commandInfos">Array of command information.</param>
    /// <returns>An array of instantiated GPL commands.</returns>

    public static IGPLCommand[] CreateCommandList(CommandInfo[] commandInfos)
    {
        List<IGPLCommand> commands = new();
        try
        {
            foreach (CommandInfo commandInfo in commandInfos)
            {
                string commandName = commandInfo.Command.ToLower();
                if (!_commandTokenMap.TryGetValue(commandName, out Type? commandType))
                {
                    if (GlobalDataList.Instance.Variables.ContainsKey(commandName))
                    {
                        commands.Add(new ReassignVariable(commandInfo));
                        continue;
                    }
                    MessageBox.Show($"Command Error {commandInfo.Command}", "Command not found");
                    return Array.Empty<IGPLCommand>();
                }
                if ((IGPLCommand?)Activator.CreateInstance(commandType, commandInfo) is { } instancedCommand &&
                    instancedCommand.IsValid())
                {
                    commands.Add(instancedCommand);
                }
                else
                {
                    // Error Handling
                    MessageBox.Show($"Command {commandInfo.Command} fell over", "Command creation error!");
                }
            }
        }
        catch
        {
            // TODO: Catch if something goes very wrong.
        }

        return commands.ToArray();
    }
}