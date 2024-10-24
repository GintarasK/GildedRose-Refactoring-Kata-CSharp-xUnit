using System.Collections.Generic;

using GildedRoseKata.Models;

namespace GildedRoseKata.Services;

internal interface IConsoleService
{
    void DisplayItems(IList<Item> items, int days, int startDay = 0);

    (bool Escape, string Line) ReadLineWithEscape();
}