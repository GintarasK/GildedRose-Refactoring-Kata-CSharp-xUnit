using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class Conjured : StandardItem
{
    public override void AgeSingleDay()
    {
        SellIn--;

        if (Quality > CommonSettings.Quality.Min)
        {
            Quality -= 2;

            if (SellIn < 0 && Quality > CommonSettings.Quality.Min)
            {
                Quality -= 2;
            }
        }
    }
}