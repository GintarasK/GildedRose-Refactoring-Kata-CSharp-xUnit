using FluentAssertions;

using GildedRoseKata.Services;

using Microsoft.Extensions.Logging.Abstractions;

using Moq;

using Xunit;

namespace GildedRoseTests.Services;

public class ProcessingServiceTests
{
    private readonly Mock<IItemInformationService> itemInformationServiceMock = new();
    private readonly Mock<IAgingService> agingServiceMock = new();

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(4, 11, 15)]
    public void ProcessAndGetLastDayToRecorded_When_CorrectParameterArePAssed_Should_ReturnExpectedResult(
        int lastDayRecorded,
        int daysToAge,
        int expectedLastDayRecorded)
    {
        // Arrange
        var daysString = daysToAge.ToString();

        agingServiceMock
            .Setup(q => q.AgeItemsSingleDay());

        itemInformationServiceMock
            .Setup(
                q => q.GetInformationOnItems(
                    It.Is<int>(w => w >= lastDayRecorded && w < expectedLastDayRecorded)));

        var sut = GetSut();

        // Act
        var result = sut.ProcessAndGetLastDayToRecorded(lastDayRecorded, daysString);

        // Assert
        result.Should().Be(expectedLastDayRecorded);

        agingServiceMock
            .Verify(
                q => q.AgeItemsSingleDay(),
                Times.Exactly(daysToAge));
        agingServiceMock.VerifyNoOtherCalls();

        itemInformationServiceMock
            .Verify(
                q => q.GetInformationOnItems(
                    It.Is<int>(w => w >= lastDayRecorded && w < expectedLastDayRecorded)),
                Times.Exactly(daysToAge));
        itemInformationServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetItems_When_ItemsArePassedOnCreation_Should_ReturnPassedItems()
    {
        // Arrange
        const int lastDayRecorded = 1;

        var daysString = "text";

        agingServiceMock
            .Setup(q => q.AgeItemsSingleDay());

        itemInformationServiceMock
            .Setup(
                q => q.GetInformationOnItems(0));

        var sut = GetSut();

        // Act
        var result = sut.ProcessAndGetLastDayToRecorded(lastDayRecorded, daysString);

        // Assert
        result.Should().Be(lastDayRecorded);

        agingServiceMock
            .Verify(
                q => q.AgeItemsSingleDay(),
                Times.Never);

        itemInformationServiceMock
            .Verify(
                q => q.GetInformationOnItems(0),
                Times.Exactly(0));

        itemInformationServiceMock.VerifyNoOtherCalls();
    }

    private ProcessingService GetSut()
        => new(
            itemInformationServiceMock.Object,
            agingServiceMock.Object,
            new NullLogger<ProcessingService>());
}
