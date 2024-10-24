using System.Collections.Generic;

using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

internal interface IItemObserver
{
    IList<Item> GetItems();
}