using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class Conjured : StandardItem
{
    protected override void AgeSingleDayInternal()
    {
        SellIn--;

        if (Quality <= CommonSettings.Quality.Min)
        {
            return;
        }

        Quality -= 2;

        if (SellIn < 0 && Quality > CommonSettings.Quality.Min)
        {
            Quality -= 2;
        }
    }
}