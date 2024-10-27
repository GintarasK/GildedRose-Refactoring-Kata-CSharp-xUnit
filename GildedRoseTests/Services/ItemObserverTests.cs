using System.Collections.Generic;

using FluentAssertions;

using GildedRoseKata.Models;
using GildedRoseKata.Services;

using Xunit;

// ReSharper disable ExpressionIsAlwaysNull
namespace GildedRoseTests.Services;

public class ItemObserverTests
{
    [Fact]
    public void GetItems_When_ItemsArePassedOnCreation_Should_ReturnPassedItems()
    {
        // Arrange
        List<Item> items = [new()];

        var sut = new ItemObserver(items);

        // Act
        var result = sut.GetItems();

        // Assert
        result.Should().BeSameAs(items);
    }

    [Fact]
    public void GetItems_When_ItemsAreNull_Should_ReturnEmptyList()
    {
        // Arrange
        List<Item> items = null;

        var sut = new ItemObserver(items);

        // Act
        var result = sut.GetItems();

        // Assert
        result.Should().BeEmpty();
    }
}
