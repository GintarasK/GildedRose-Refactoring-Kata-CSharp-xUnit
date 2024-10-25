using System.Text;

using GildedRoseKata.Extensions;

namespace GildedRoseKata.Services;

internal class ItemInformationService(
    IItemObserver itemObserver)
    : IItemInformationService
{
    public string GetInformationOnItems(int day)
    {
        var items = itemObserver.GetItems();

        var dayInformation = new StringBuilder();
        dayInformation.AppendLine();
        dayInformation.AppendLine($"--------day {day} --------".PadCenter(72));
        dayInformation.AppendLine($"{"Name",-50}|{"SellIn",-10}|{"Quality",-10}");
        foreach (var item in items)
        {
            var itemInfo = $"{item.Name,-50}|{item.SellIn,-10}|{item.Quality,-10}";
            dayInformation.AppendLine(itemInfo);
        }

        return dayInformation.ToString();
    }
}
