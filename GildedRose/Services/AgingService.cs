using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

internal class AgingService(IItemObserver itemObserver) : IAgingService
{
    public void AgeItemsSingleDay()
    {
        var items = itemObserver.GetItems();

        foreach (var item in items)
        {
            (item as StandardItem).AgeSingleDay();
        }
    }
}