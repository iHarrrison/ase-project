namespace GraphicProgrammingLanguage.Model;

using Utility;
using Model;
using GraphicProgrammingLanguage.Commands;

/// <summary>
/// Represents a global data list for the solution, storing variables and methods.
/// </summary>
public class GlobalDataList
{
    private static GlobalDataList _instance = new();

    /// <summary>
    /// Gets the singleton instance of the <see cref="GlobalDataList"/>. Enforces only once Global Data List
    /// instance is active at any given time
    /// </summary>
    public static GlobalDataList Instance => _instance;

    /// <summary>
    /// Gets the collection of variables stored in the GlobalDataList.
    /// </summary>
    public SortedDictionary<string, int> Variables { get; } = new(new DescendingKeyLengthComparer());
    
    /// <summary>
    /// Gets the collection of defined methods stored in the GlobalDataList.
    /// </summary>
    public SortedDictionary<string, DefineMethod> Methods { get; } = new(new DescendingKeyLengthComparer());


    /// <summary>
    /// Static constructor to initialize the singleton instance.
    /// </summary>
    static GlobalDataList() { }

    /// <summary>
    /// Private constructor to enforce the singleton pattern.
    /// </summary>
    private GlobalDataList() { }

    // Clears the data list variables and methods - important for reusing variable and method names
    // in the same instance of the program running
    public void ClearData()
    {
        Variables.Clear();
        Methods.Clear();
    }
}
