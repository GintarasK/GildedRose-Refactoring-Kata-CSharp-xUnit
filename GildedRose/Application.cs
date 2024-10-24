using System;
using System.Collections.Generic;

using GildedRoseKata.Models;
using GildedRoseKata.Services;

using Microsoft.Extensions.Logging;

namespace GildedRoseKata;

internal class Application(
    IConsoleService consoleService,
    ILogger<Application> logger)
{
    public void Process()
    {
        logger.LogInformation("OMGHAI!");

        IList<Item> items = DataProvider.Items;

        var lastDay = 0;

        do
        {
            logger.LogInformation("Please enter amount of days passed and press ENTER.  (ESC to cancel): ");
            var (escape, daysString) = consoleService.ReadLineWithEscape();

            if (escape)
            {
                break;
            }

            lastDay = DisplayItemsAgingInDays(items, lastDay, daysString);

            logger.LogInformation("Please press Any Key to continue. (ESC to cancel): ");
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private int DisplayItemsAgingInDays(IList<Item> items, int lastRecordedDay, string daysString)
    {
        var daysToPass = GetDaysArgument(daysString);

        var lastDayToRecord = lastRecordedDay + daysToPass;
        consoleService.DisplayItems(items, lastDayToRecord, lastRecordedDay);

        return lastDayToRecord;
    }

    private int GetDaysArgument(string dayArgument)
    {
        if (!int.TryParse(dayArgument, out int days))
        {
            logger.LogInformation($"DayArgument: '{dayArgument}' was not parsed into days.");
        }

        return days;
    }
}
