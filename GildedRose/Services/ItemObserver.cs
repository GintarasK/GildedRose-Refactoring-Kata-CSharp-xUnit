using System.Collections.Generic;

using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

internal class ItemObserver(IList<Item> items) : IItemObserver
{
    private readonly IList<Item> items = items;

    public IList<Item> GetItems() => items;
}
