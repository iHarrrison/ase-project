using System.Reflection;

namespace GraphicProgrammingLanguage.Factory;

using Commands;
using Model;

public static class CommandFactory
{
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
    };

    public static IGPLCommand[] CreateCommandListNew(CommandInfo[] commandInfos)
    {
        List<IGPLCommand> commands = new();
        try
        {
            foreach (CommandInfo commandInfo in commandInfos)
            {
                if (!_commandTokenMap.TryGetValue(commandInfo.Command.ToLower(), out Type? commandType))
                {
                    MessageBox.Show($"Error with entered command {commandInfo.Command}", "Command not found!");
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
                    MessageBox.Show($"Command {commandInfo.Command} fell over", "Command creation error!"); // todo: change me
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