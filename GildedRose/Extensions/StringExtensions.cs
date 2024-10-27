namespace GildedRoseKata.Extensions;

internal static class StringExtensions
{
    public static string PadCenter(this string str, int length)
    {
        if (length <= str.Length)
        {
            return str;
        }

        var spaces = length - str.Length;
        var padLeft = (spaces / 2) + str.Length;
        return str.PadLeft(padLeft).PadRight(length);
    }
}
