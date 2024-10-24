using System;
using System.Collections.Generic;

using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = DataProvider.Items;

        var app = new GildedRose(items);

        int days = GetDaysArgument(args);

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }

            Console.WriteLine();
            app.UpdateQuality();
        }
    }

    private static int GetDaysArgument(string[] args)
    {
        int days = 2;
        if (args.Length > 0)
        {
            var dayArgument = args[0];

            if (!int.TryParse(args[0], out days))
            {
                Console.WriteLine($"DayArgument: '{dayArgument}' was not parsed into days.");
            }
        }

        return days;
    }
}