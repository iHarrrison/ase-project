namespace GraphicProgrammingLanguage.Model;

/// <summary>
/// Contains constant values used throughout GraphicProgrammingLanguage.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Represents the newline character sequence.
    /// </summary>
    public const string NewLine = "\r\n";

    /// <summary>
    /// Represents the split options used when splitting arguments (to keep it tidy).
    /// </summary>
    public const StringSplitOptions ArgumentSplitFlags = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    /// <summary>
    /// Represents an array of reserved operators that are used throughout.
    /// </summary>
    public static readonly char[] ReservedNames = { '+', '-', '/', '*', '!', '=', '<', '>', ' ' };
}