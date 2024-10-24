using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class AgedBrie : StandardItem
{
    public override void AgeSingleDay()
    {
        SellIn--;

        if (Quality < CommonSettings.Quality.Max)
        {
            Quality++;
        }
    }
}
