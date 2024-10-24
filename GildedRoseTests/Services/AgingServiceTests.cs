using System;
using System.Collections.Generic;

using FluentAssertions;

using GildedRoseKata.Models;
using GildedRoseKata.Services;

using Moq;

using Xunit;

namespace GildedRoseTests.Services;

public class AgingServiceTests
{
    private readonly Mock<IItemObserver> itemObserverMock = new();

    [Fact]
    public void AgeItemsSingleDay_When_AllItemsAreStandardItem_Should_AgeItems()
    {
        // Arrange
        IList<Item> items = [new StandardItem { Quality = 1, SellIn = 1 }];

        itemObserverMock
            .Setup(q => q.GetItems())
            .Returns(items)
            .Verifiable();

        var sut = GetSut();

        // Act
        sut.AgeItemsSingleDay();

        // Assert
        var result = items[0];
        result.Quality.Should().Be(0);
        result.SellIn.Should().Be(0);

        itemObserverMock.Verify();
    }

    [Fact]
    public void AgeItemsSingleDay_When_NotAllAllItemsAreStandardItem_Should_ThrowNotImplementedException()
    {
        // Arrange
        List<Item> items = [new()];

        itemObserverMock
            .Setup(q => q.GetItems())
            .Returns(items)
            .Verifiable();

        var sut = GetSut();

        // Act
        var exception = Record.Exception(() => sut.AgeItemsSingleDay());

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<NotImplementedException>();
        exception.Message.Should().Contain("not implemented");

        itemObserverMock.Verify();
    }

    private AgingService GetSut()
        => new(itemObserverMock.Object);
}
