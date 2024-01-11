namespace GraphicProgrammingLanguage.Model;

using Utility;
using Model;
using GraphicProgrammingLanguage.Commands;

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

    public SortedDictionary<string, int> Variables { get; } = new(new DescendingKeyLengthComparer());
    public SortedDictionary<string, DefineMethod> Methods { get; } = new(new DescendingKeyLengthComparer());


    /// <summary>
    /// Static constructor to initialize the singleton instance.
    /// </summary>
    static GlobalDataList() { }

    /// <summary>
    /// Private constructor to enforce the singleton pattern.
    /// </summary>
    private GlobalDataList() { }

    public void ClearData()
    {
        Variables.Clear();
        Methods.Clear();
    }
}
