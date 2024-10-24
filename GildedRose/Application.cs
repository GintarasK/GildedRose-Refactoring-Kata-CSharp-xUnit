using System;

using GildedRoseKata.Services;

using Microsoft.Extensions.Logging;

namespace GildedRoseKata;

internal class Application(
    IConsoleService consoleService,
    IAgingService agingService,
    ILogger<Application> logger)
{
    private const int DefaultInitialDaysValue = 0;

    public void Process()
    {
        logger.LogInformation("OMGHAI!");

        var lastDayRecorded = DefaultInitialDaysValue;

        do
        {
            logger.LogInformation("Please enter amount of days passed and press ENTER.  (ESC to cancel): ");
            var (escape, daysString) = consoleService.ReadLineWithEscape();

            if (escape)
            {
                break;
            }

            var lastDayToRecord = CalculateLastDayToRecord(lastDayRecorded, daysString);

            ProcessItems(lastDayToRecord, lastDayRecorded);

            lastDayRecorded = lastDayToRecord;

            logger.LogInformation("Please press Any Key to continue. (ESC to cancel): ");
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private void ProcessItems(int days, int startDay = 0)
    {
        for (var i = startDay; i < days; i++)
        {
            agingService.AgeItemsSingleDay();
            consoleService.DisplayItems(day: i);
        }
    }

    private int CalculateLastDayToRecord(int lastRecordedDay, string daysString)
    {
        var daysToPass = GetDaysArgument(daysString);
        var lastDayToRecord = lastRecordedDay + daysToPass;
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
