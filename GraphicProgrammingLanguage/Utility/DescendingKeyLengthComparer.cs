namespace GraphicProgrammingLanguage.Utility;

public class DescendingKeyLengthComparer : IComparer<string>
{
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