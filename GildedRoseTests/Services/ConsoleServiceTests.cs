using System;

using FluentAssertions;

using GildedRoseKata.Services;
using GildedRoseKata.Services.Wrappers;

using Moq;

using Xunit;

namespace GildedRoseTests.Services;

public class ConsoleServiceTests
{
    private readonly Mock<IConsoleWrapper> consoleWrapperMock = new();

    [Fact]
    public void ReadLineWithEscape_When_EnterIsPressed_Should_EscapeBeFalse()
    {
        // Arrange
        consoleWrapperMock
            .SetupSequence(q => q.ReadKey(true))
            .Returns(GetKeyInfo('1', ConsoleKey.NumPad1))
            .Returns(GetKeyInfo('1', ConsoleKey.NumPad1))
            .Returns(GetKeyInfo(' ', ConsoleKey.Enter));

        consoleWrapperMock
            .Setup(q => q.Write(It.IsAny<char>()));

        var sut = GetSut();

        // Act
        var result = sut.ReadLineWithEscape();

        // Assert
        result.Should().NotBeNull();
        result.Escape.Should().BeFalse();
        result.Line.Should().Be("11");
    }

    [Fact]
    public void ReadLineWithEscape_When_EnterIsPressed_Should_EscapeBeTrue()
    {
        // Arrange
        consoleWrapperMock
            .SetupSequence(q => q.ReadKey(true))
            .Returns(GetKeyInfo('1', ConsoleKey.NumPad1))
            .Returns(GetKeyInfo('1', ConsoleKey.NumPad1))
            .Returns(GetKeyInfo(' ', ConsoleKey.Escape));

        consoleWrapperMock
            .Setup(q => q.Write(It.IsAny<char>()));

        var sut = GetSut();

        // Act
        var result = sut.ReadLineWithEscape();

        // Assert
        result.Should().NotBeNull();
        result.Escape.Should().BeTrue();
        result.Line.Should().BeNull();
    }

    private static ConsoleKeyInfo GetKeyInfo(char keyChar, ConsoleKey key)
        => new(keyChar, key, false, false, false);

    private ConsoleService GetSut()
        => new(consoleWrapperMock.Object);
}
