﻿namespace GildedRoseKata.Extensions;

internal static class StringExtensions
{
    public static string PadCenter(this string str, int length)
    {
        if (length > str.Length)
        {
            int spaces = length - str.Length;
            int padLeft = (spaces / 2) + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }

        return str;
    }
}
