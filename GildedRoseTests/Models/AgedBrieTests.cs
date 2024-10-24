using FluentAssertions;

using GildedRoseKata.Models;

using Xunit;

namespace GildedRoseTests.Models;

public class AgedBrieTests
{
    [Theory]

    // Quality tests
    [InlineData(0, 22, 1, 21)]
    [InlineData(2, 0, 3, -1)]
    [InlineData(2, -1, 3, -2)]
    [InlineData(1, 1, 2, 0)]
    [InlineData(0, -1, 1, -2)]
    public void AgeSingleDay_When_UsingTestingVariables_Should_HaveExpectedValues(
        int quality,
        int sellIn,
        int expectedQuality,
        int expectedSellIn)
    {
        // Arrange
        var item = new AgedBrie { Name = "A", Quality = quality, SellIn = sellIn };

        // Act
        item.AgeSingleDay();

        // Assert
        item.Quality.Should().Be(expectedQuality);
        item.SellIn.Should().Be(expectedSellIn);
    }
}