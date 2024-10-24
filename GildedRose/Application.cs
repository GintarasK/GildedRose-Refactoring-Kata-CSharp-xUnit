using System;

using GildedRoseKata.Services;

using Microsoft.Extensions.Logging;

namespace GildedRoseKata;

internal class Application(
    IConsoleService consoleService,
    IProcessingService processingService,
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

            lastDayRecorded = processingService.ProcessAndGetLastDayToRecorded(lastDayRecorded, daysString);
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}
