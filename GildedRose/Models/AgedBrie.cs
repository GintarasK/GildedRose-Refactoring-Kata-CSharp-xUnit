using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class AgedBrie : StandardItem
{
    protected override void AgeSingleDayInternal()
    {
        SellIn--;

        if (Quality < CommonSettings.Quality.Max)
        {
            Quality++;
        }
    }
}
