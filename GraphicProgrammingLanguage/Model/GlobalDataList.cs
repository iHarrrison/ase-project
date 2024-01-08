namespace GraphicProgrammingLanguage.Model;

public class GlobalDataList
{
    private static GlobalDataList _instance = new();
    public static GlobalDataList Instance => _instance;
    public Dictionary<string, int?> Variables { get; } = new();

    static GlobalDataList() { }
    private GlobalDataList() { }
}
