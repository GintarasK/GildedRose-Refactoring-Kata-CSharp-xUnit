using System.Collections.Generic;

using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

// NOTE: If there is a need for permanent storage, remove ItemObserver and create Read/Write Repositories communicating with Database (DB Access Layer).
internal class ItemObserver(IList<Item> items) : IItemObserver
{
    private readonly IList<Item> items = items ?? [];

    public IList<Item> GetItems() => items;
}
