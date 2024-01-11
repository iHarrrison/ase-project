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
        {"method", typeof(DefineMethod) },
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
                if (!(TryInstantiateCommand(commandInfo, out IGPLCommand? instancedCommand) &&
                    instancedCommand!.IsValid()))
                {
                    continue;
                }

                if (instancedCommand is not DefineMethod)
                {
                    commands.Add(instancedCommand);
                }
            }
        }

        catch
        {
            // TODO: Catch if something goes very wrong.
        }

        return commands.ToArray();
    }

    /// <summary>
    /// Attempts to instantiate commands.
    /// </summary>
    /// <param name="commandInfos">Array of command information.</param>
    /// <returns>An array of instantiated GPL commands.</returns>
    private static bool TryInstantiateCommand(CommandInfo commandInfo, out IGPLCommand? command)
    {
        command = null;
        string commandName = commandInfo.Command.ToLower();

        if (_commandTokenMap.TryGetValue(commandName, out Type? commandType))
        {
            if ((IGPLCommand?)Activator.CreateInstance(commandType, commandInfo) is { } instancedCommand)
            {
                command = instancedCommand;
                return true;
            }

            // Error - I need to look at better way of doing this
            MessageBox.Show($"Command has fallen over: {commandInfo.Command}", "Command creation error!");
            return false;
        }

        if (GlobalDataList.Instance.Variables.ContainsKey(commandName))
        {
            command = new ReassignVariable(commandInfo);
            return true;
        }

        string methodName = DefineMethod.GetMethodNameFromDeclaration(commandName);
        if (GlobalDataList.Instance.Methods.ContainsKey(methodName))
        {
            commandInfo.Command = methodName;
            commandInfo.Arguments = string.Join(',', DefineMethod.GetMethodParametersFromDeclaration(commandName));
            command = new CallMethod(commandInfo);
            return true;
        }
        // Error - I need to look at better way of doing this
        MessageBox.Show($"The following Command is not valid: {commandInfo.Command}", "Command not found!");
        return false;
    }
}