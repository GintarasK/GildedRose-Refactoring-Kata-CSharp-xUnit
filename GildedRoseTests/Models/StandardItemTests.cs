using FluentAssertions;

using GildedRoseKata.Models;

using Xunit;

namespace GildedRoseTests.Models;

public class StandardItemTests
{
    [Theory]
    [InlineData(0, 22, 0, 21)]
    [InlineData(2, 0, 0, -1)]
    [InlineData(2, -1, 0, -2)]
    [InlineData(1, 1, 0, 0)]
    [InlineData(0, -1, 0, -2)]
    [InlineData(-1, 1, 0, 0)]
    [InlineData(100, 1, 50, 0)]
    public void AgeSingleDay_When_UsingTestingVariables_Should_HaveExpectedValues(
        int quality,
        int sellIn,
        int expectedQuality,
        int expectedSellIn)
    {
        // Arrange
        var item = new StandardItem { Name = "A", Quality = quality, SellIn = sellIn };

        // Act
        item.AgeSingleDay();

        // Assert
        item.Quality.Should().Be(expectedQuality);
        item.SellIn.Should().Be(expectedSellIn);
    }
}