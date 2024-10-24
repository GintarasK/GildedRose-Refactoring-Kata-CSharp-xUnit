using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public class StandardItem : Item
{
    protected virtual int MaxQuality { get; } = CommonSettings.Quality.Max;

    public void AgeSingleDay()
    {
        AgeSingleDayInternal();

        if (Quality < CommonSettings.Quality.Min)
        {
            Quality = CommonSettings.Quality.Min;
        }

        if (Quality > MaxQuality)
        {
            Quality = MaxQuality;
        }
    }

    protected virtual void AgeSingleDayInternal()
    {
        SellIn--;

        if (Quality > CommonSettings.Quality.Min)
        {
            Quality--;

            if (SellIn < 0 && Quality > CommonSettings.Quality.Min)
            {
                Quality--;
            }
        }
    }
}
