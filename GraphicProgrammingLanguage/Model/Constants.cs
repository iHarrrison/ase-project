namespace GraphicProgrammingLanguage.Model;
public static class Constants
{
    public const string NewLine = "\r\n";
    public const StringSplitOptions ArgumentSplitFlags = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
    public static readonly char[] ReservedNames = { '+', '-', '/', '*', '!', '=', '<', '>', ' ' };
}