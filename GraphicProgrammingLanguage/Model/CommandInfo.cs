namespace GraphicProgrammingLanguage.Model;

/// <summary>
/// Represents information about a given command.
/// </summary>
public class CommandInfo
{
    /// <summary>
    /// Gets or sets the command keyword.
    /// </summary>
    public string Command { get; set; } = "";

    // <summary>
    /// Gets or sets the arguments associated with the command.
    /// </summary>
    public string Arguments { get; set; } = "";


    /// <summary>
    /// Gets or sets the list of command information for the true condition of a conditional command.
    /// </summary>
    public List<CommandInfo> TrueConditionCommandInfos { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of command information for the false condition of a conditional command.
    /// </summary>
    public List<CommandInfo> FalseConditionCommandInfos { get; set; } = new();
}