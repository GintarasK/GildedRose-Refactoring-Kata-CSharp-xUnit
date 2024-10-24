using FluentAssertions;

using GildedRoseKata.Common;
using GildedRoseKata.Models;

using Xunit;

namespace GildedRoseTests.Models;

public class SulfurasTests
{
    [Theory]

    // Quality tests
    [InlineData(0, 22, CommonSettings.Quality.Legendary, 21)]
    [InlineData(2, 0, CommonSettings.Quality.Legendary, -1)]
    [InlineData(2, -1, CommonSettings.Quality.Legendary, -2)]
    [InlineData(1, 1, CommonSettings.Quality.Legendary, 0)]
    [InlineData(0, -1, CommonSettings.Quality.Legendary, -2)]
    [InlineData(100, 1, CommonSettings.Quality.Legendary, 0)]
    public void AgeSingleDay_When_UsingTestingVariables_Should_HaveExpectedValues(
        int quality,
        int sellIn,
        int expectedQuality,
        int expectedSellIn)
    {
        // Arrange
        var item = new Sulfuras { Name = "A", Quality = quality, SellIn = sellIn };

        // Act
        item.AgeSingleDay();

        // Assert
        item.Quality.Should().Be(expectedQuality);
        item.SellIn.Should().Be(expectedSellIn);
    }
}