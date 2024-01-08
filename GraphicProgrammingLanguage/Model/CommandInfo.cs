namespace GraphicProgrammingLanguage.Model;

public class CommandInfo
{
    public string Command { get; set; } = "";
    public string Arguments { get; set; } = "";
    public List<CommandInfo> TrueConditionCommandInfos { get; set; } = new();
    public List<CommandInfo> FalseConditionCommandInfos { get; set; } = new();
}