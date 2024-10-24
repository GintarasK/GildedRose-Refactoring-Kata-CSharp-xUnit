namespace GildedRoseKata.Services;

internal interface IProcessingService
{
    int ProcessAndGetLastDayToRecorded(int lastDayRecorded, string daysString);
}