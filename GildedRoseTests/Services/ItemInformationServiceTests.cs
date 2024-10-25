using System.Collections.Generic;

using FluentAssertions;

using GildedRoseKata.Models;
using GildedRoseKata.Services;

using Moq;

using Xunit;

namespace GildedRoseTests.Services;

public class ItemInformationServiceTests
{
    private readonly Mock<IItemObserver> itemObserverMock = new();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetItems_When_ItemsArePassedOnCreation_Should_ReturnPassedItems(
        int day)
    {
        // Arrange
        IList<Item> items = [
            new StandardItem { Name = "StandardItem", Quality = 50, SellIn = 5, },
            new AgedBrie { Name = "AgedBrie", Quality = 30, SellIn = 10, },
            new Conjured { Name = "Conjured", Quality = 15, SellIn = 15, },
        ];

        itemObserverMock
            .Setup(q => q.GetItems())
            .Returns(items)
            .Verifiable();

        var sut = GetSut();

        // Act
        var result = sut.GetInformationOnItems(day);

        // Assert
        result.Should().Be(GetExpectedDisplayResult(day));

        itemObserverMock.Verify();
        itemObserverMock.VerifyNoOtherCalls();
    }

    private static string GetExpectedDisplayResult(int day) => $@"
                         --------day {day} --------                         
Name                                              |SellIn    |Quality   
StandardItem                                      |5         |50        
AgedBrie                                          |10        |30        
Conjured                                          |15        |15        
";

    private ItemInformationService GetSut()
        => new(
            itemObserverMock.Object);
}
