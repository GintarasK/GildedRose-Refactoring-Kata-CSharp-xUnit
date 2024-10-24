using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class Sulfuras : StandardItem
{
    public Sulfuras()
    {
        Quality = CommonSettings.Quality.Legendary;
    }

    public override void AgeSingleDay()
    {
        SellIn--;

        Quality = CommonSettings.Quality.Legendary;
    }
}
