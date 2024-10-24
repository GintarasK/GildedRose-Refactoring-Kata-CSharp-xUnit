using FluentAssertions;

using GildedRoseKata.Models;

using Xunit;

namespace GildedRoseTests.Models;

public class BackstagePassTests
{
    [Theory]

    // SellIn > 10
    [InlineData(0, 22, 1, 21)]

    // SellIn < 0
    [InlineData(2, 0, 0, -1)]
    [InlineData(10, -1, 0, -2)]

    // SellIn <= 5 && SellIn > 0
    [InlineData(0, 6, 3, 5)]
    [InlineData(0, 2, 3, 1)]

    // SellIn <= 10 && SellIn > 5
    [InlineData(0, 7, 2, 6)]
    [InlineData(0, 11, 2, 10)]

    public void AgeSingleDay_When_UsingTestingVariables_Should_HaveExpectedValues(
        int quality,
        int sellIn,
        int expectedQuality,
        int expectedSellIn)
    {
        // Arrange
        var item = new BackstagePass { Name = "A", Quality = quality, SellIn = sellIn };

        // Act
        item.AgeSingleDay();

        // Assert
        item.Quality.Should().Be(expectedQuality);
        item.SellIn.Should().Be(expectedSellIn);
    }
}