using System;

using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

internal class AgingService(IItemObserver itemObserver) : IAgingService
{
    public void AgeItemsSingleDay()
    {
        var items = itemObserver.GetItems();

        foreach (var item in items)
        {
            AgeItem(item);
        }
    }

    private static void AgeItem(Item item)
    {
        if (item is not StandardItem standardItem)
        {
            throw new NotImplementedException($"{item?.GetType()} is not implemented.");
        }

        standardItem.AgeSingleDay();
    }
}