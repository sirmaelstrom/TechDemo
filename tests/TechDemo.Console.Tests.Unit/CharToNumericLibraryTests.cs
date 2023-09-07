using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class CharToNumericLibraryTests
{
    private CharToNumeric _sut = new();

    [Theory]
    [InlineData('A', 1)]
    [InlineData('B', 2)]
    [InlineData('C', 3)]
    public void CharToCustomValue_ShouldConvertCharToInt_WhenInputValid(char input, int expectedResult)
    {
        // Act
        var result = _sut.CharToCustomValue(input);
        
        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void CharToCustomValue_ShouldReturnDefault_WhenInputNotMapped()
    {
        // Arrange
        var input = 'Z';
        var expectedResult = -1;

        // Act
        var result = _sut.CharToCustomValue(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void CharToUnicodeCodePoint_ShouldReturnInt_WhenInputValid()
    {
        // Arrange
        var input = 'J';
        var expectedResult = 74;

        // Act
        var result = _sut.CharToUnicodeCodePoint(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void DigitCharToNumericValue_ShouldReturnDigit_WhenDigitChar()
    {
        // Arrange
        var input = '5';
        var expectedResult = 5;

        // Act
        var result = _sut.DigitCharToNumericValue(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void DigitCharToNumericValue_ShouldReturnDefault_WhenNotDigitChar()
    {
        // Arrange
        var input = 'Z';
        var expectedResult = -1;

        // Act
        var result = _sut.DigitCharToNumericValue(input);

        // Assert
        result.Should().Be(expectedResult);
    }
}