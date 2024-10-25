using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.Models;

public sealed class BackstagePass : StandardItem
{
    private readonly List<Strategy> agingStrategies =
    [
        new((sellIn) => sellIn < 0, (_) => 0),
        new((sellIn) => sellIn is <= 10 and > 5, (quality) => quality + 2),
        new((sellIn) => sellIn is <= 5 and > 0, (quality) => quality + 3),
        new((sellIn) => sellIn > 10, (quality) => quality + 1),
    ];

    protected override void AgeSingleDayInternal()
    {
        SellIn--;

        ExecuteAgingStrategy();
    }

    private void ExecuteAgingStrategy()
    {
        foreach (var strategy in agingStrategies.Where(strategy => strategy.Condition(SellIn)))
        {
            Quality = strategy.Action(Quality);
        }
    }

    private class Strategy(Func<int, bool> condition, Func<int, int> action)
    {
        public Func<int, bool> Condition { get; set; } = condition;

        public Func<int, int> Action { get; set; } = action;
    }
}
