using System;
using System.Text;

using GildedRoseKata.StringExtensions;

namespace GildedRoseKata.Services;

internal class ConsoleService(
    IItemObserver itemObserver)
    : IConsoleService
{
    public void DisplayItems(int day)
    {
        var items = itemObserver.GetItems();

        var dayInformation = new StringBuilder();
        dayInformation.AppendLine();
        dayInformation.AppendLine($"--------day {day} --------".PadCenter(72));
        dayInformation.AppendLine($"{"Name",-50}|{"SellIn",-10}|{"Quality",-10}");
        for (var j = 0; j < items.Count; j++)
        {
            var itemInfo = $"{items[j].Name,-50}|{items[j].SellIn,-10}|{items[j].Quality,-10}";
            dayInformation.AppendLine(itemInfo);
        }

        Console.Write(dayInformation.ToString());
    }

    public (bool Escape, string Line) ReadLineWithEscape()
    {
        string result = null;

        StringBuilder buffer = new();

        ConsoleKeyInfo info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
        {
            Console.Write(info.KeyChar);
            buffer.Append(info.KeyChar);
            info = Console.ReadKey(true);
        }

        if (info.Key == ConsoleKey.Enter)
        {
            result = buffer.ToString();
        }

        if (info.Key == ConsoleKey.Escape)
        {
            return (true, null);
        }

        return (false, result);
    }
}