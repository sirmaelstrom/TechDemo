using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class IntegerLibraryTests
{
    private IntegerLibraryWrapper _sut = new();
    
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(5, true)]
    [InlineData(7, true)]
    [InlineData(11, true)]
    [InlineData(71, true)]
    public void IsPrime_ShouldReturnTrue_WhenIntegerIsPrime(int input, bool expectedResult)
    {
        // Act
        var result = _sut.IsPrime(input);
        
        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(10, false)]
    [InlineData(30, false)]
    [InlineData(49, false)]
    [InlineData(100, false)]
    public void IsPrime_ShouldReturnFalse_WhenIntegerIsNotPrime(int input, bool expectedResult)
    {
        // Act
        var result = _sut.IsPrime(input);
        
        // Assert
        result.Should().Be(expectedResult);
    }
    
}