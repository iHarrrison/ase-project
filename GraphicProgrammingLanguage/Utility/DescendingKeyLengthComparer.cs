namespace GraphicProgrammingLanguage.Utility;

/// <summary>
/// Compares strings and sorts them in descending order based on their length.
/// </summary>
public class DescendingKeyLengthComparer : IComparer<string>
{
    /// <summary>
    /// Compares two strings in descending order based on their length.
    /// </summary>
    /// <param name="x">The first string to compare.</param>
    /// <param name="y">The second string to compare.</param>
    /// <returns>
    /// A negative value if x is greater, a positive value if y is greater,
    /// and zero if the lengths are equal (compares lexicographically in descending order in case of equal lengths).
    /// </returns>
    public int Compare(string? x, string? y)
    {
        if (x == null)
        {
            return 1;
        }
        if (y == null)
        {
            return -1;
        }
        int comparison = x.Length.CompareTo(y.Length);
        return comparison == 0 ? string.Compare(y, x, StringComparison.Ordinal) : -comparison;
    }
}