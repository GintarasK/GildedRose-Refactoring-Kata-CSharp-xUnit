using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public sealed class Sulfuras : StandardItem
{
    public Sulfuras()
    {
        Quality = CommonSettings.Quality.Legendary;
    }

    protected override int MaxQuality { get; } = CommonSettings.Quality.Legendary;

    protected override void AgeSingleDayInternal()
    {
        SellIn--;

        Quality = CommonSettings.Quality.Legendary;
    }
}
