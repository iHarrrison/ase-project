namespace GraphicProgrammingLanguage.Model;

/// <summary>
/// Represents a global data list containing variables used throughout Graphic Programming Language.
/// </summary>
public class GlobalDataList
{
    private static GlobalDataList _instance = new();

    /// <summary>
    /// Gets the singleton instance of the <see cref="GlobalDataList"/>.
    /// </summary>
    public static GlobalDataList Instance => _instance;

    /// <summary>
    /// Gets a dictionary containing variable names and their corresponding values.
    /// </summary>
    public Dictionary<string, int?> Variables { get; } = new();

    /// <summary>
    /// Static constructor to initialize the singleton instance.
    /// </summary>
    static GlobalDataList() { }

    /// <summary>
    /// Private constructor to enforce the singleton pattern.
    /// </summary>
    private GlobalDataList() { }
}
