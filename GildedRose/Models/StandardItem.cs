using GildedRoseKata.Common;

namespace GildedRoseKata.Models;

public class StandardItem : Item
{
    public virtual void AgeSingleDay()
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
