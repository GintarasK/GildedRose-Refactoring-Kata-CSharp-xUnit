using FluentAssertions;

using GildedRoseKata.Extensions;

using Xunit;

namespace GildedRoseTests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void PadCenter_When_StringLengthIsMoreThanLengthVariable_Should_ReturnSameString()
    {
        // Arrange
        const string str = "1234567890";
        const int length = 1;

        // Act
        var resultStr = StringExtensions.PadCenter(str, length);

        // Assert
        resultStr.Should().BeSameAs(str);
    }

    [Fact]
    public void PadCenter_When_StringLengthIsLessThanLengthVariable_Should_ReturnSameString()
    {
        // Arrange
        const string str = "1234567890";
        const int length = 20;

        // Act
        var resultStr = StringExtensions.PadCenter(str, length);

        // Assert
        resultStr.Should().ContainAll(str);
        resultStr.Length.Should().Be(length);
    }
}
