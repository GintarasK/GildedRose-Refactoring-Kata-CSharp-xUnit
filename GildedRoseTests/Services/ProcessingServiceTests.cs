using FluentAssertions;

using GildedRoseKata.Services;

using Microsoft.Extensions.Logging.Abstractions;

using Moq;

using Xunit;

namespace GildedRoseTests.Services;

public class ProcessingServiceTests
{
    private readonly Mock<IConsoleService> consoleServiceMock = new();
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

        consoleServiceMock
            .Setup(
                q => q.DisplayItems(
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

        consoleServiceMock
            .Verify(
                q => q.DisplayItems(
                    It.Is<int>(w => w >= lastDayRecorded && w < expectedLastDayRecorded)),
                Times.Exactly(daysToAge));
        consoleServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetItems_When_ItemsArePassedOnCreation_Should_ReturnPassedItems()
    {
        // Arrange
        const int lastDayRecorded = 1;

        var daysString = "text";

        agingServiceMock
            .Setup(q => q.AgeItemsSingleDay());

        consoleServiceMock
            .Setup(
                q => q.DisplayItems(0));

        var sut = GetSut();

        // Act
        var result = sut.ProcessAndGetLastDayToRecorded(lastDayRecorded, daysString);

        // Assert
        result.Should().Be(lastDayRecorded);

        agingServiceMock
            .Verify(
                q => q.AgeItemsSingleDay(),
                Times.Never);

        consoleServiceMock
            .Verify(
                q => q.DisplayItems(0),
                Times.Exactly(0));

        consoleServiceMock.VerifyNoOtherCalls();
    }

    private ProcessingService GetSut()
        => new(
            consoleServiceMock.Object,
            agingServiceMock.Object,
            new NullLogger<ProcessingService>());
}
