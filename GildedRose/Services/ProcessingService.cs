using Microsoft.Extensions.Logging;

namespace GildedRoseKata.Services;

internal class ProcessingService(
    IItemInformationService itemInformationService,
    IAgingService agingService,
    ILogger<ProcessingService> logger)
    : IProcessingService
{
    public int ProcessAndGetLastDayToRecorded(int lastDayRecorded, string daysString)
    {
        var lastDayToRecord = CalculateLastDayToRecord(lastDayRecorded, daysString);

        ProcessItems(lastDayToRecord, lastDayRecorded);

        lastDayRecorded = lastDayToRecord;

        logger.LogInformation("Please press Any Key to continue. (ESC to cancel): ");

        return lastDayRecorded;
    }

    private void ProcessItems(int days, int startDay = 0)
    {
        for (var i = startDay; i < days; i++)
        {
            agingService.AgeItemsSingleDay();
            var itemInformation = itemInformationService.GetInformationOnItems(day: i);
            logger.LogInformation(itemInformation);
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
        if (int.TryParse(dayArgument, out var days))
        {
            return days;
        }

        logger.LogInformation("DayArgument: '{DayArgument}' was not parsed into days.", dayArgument);
        return 0;
    }
}
