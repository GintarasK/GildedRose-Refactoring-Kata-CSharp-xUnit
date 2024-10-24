using FluentAssertions;

using GildedRoseKata.Common;
using GildedRoseKata.Models;

using Xunit;

namespace GildedRoseTests.Models;

public class ConjuredTests
{
    [Theory]

    // Quality tests
    [InlineData(0, 22, 0, 21)]
    [InlineData(4, 0, 0, -1)]
    [InlineData(4, -1, 0, -2)]
    [InlineData(1, 1, 0, 0)]
    [InlineData(2, 1, 0, 0)]
    [InlineData(0, -1, 0, -2)]
    public void AgeSingleDay_When_UsingTestingVariables_Should_HaveExpectedValues(
        int quality,
        int sellIn,
        int expectedQuality,
        int expectedSellIn)
    {
        // Arrange
        var item = new Conjured { Name = "A", Quality = quality, SellIn = sellIn };

        // Act
        item.AgeSingleDay();

        // Assert
        item.Quality.Should().Be(expectedQuality);
        item.SellIn.Should().Be(expectedSellIn);
    }
}