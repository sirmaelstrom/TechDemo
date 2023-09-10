using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class ConcurrentComputationLibraryTests
{
    [Fact]
    public void CalculatePi_ShouldApproximatePi_WithValidNumberOfTerms()
    {
        // Arrange
        var numberOfTerms = 5000;
        var expectedPi = Math.PI;

        // Act
        var result = ConcurrentComputationLibrary.CalculatePi(numberOfTerms);

        // Assert
        result.Should().BeApproximately(expectedPi, 0.0001); // Adjust tolerance as needed
    }

    [Fact]
    public void CalculatePi_ShouldThrowOverflowException_WithInvalidNumberOfTerms()
    {
        // Arrange
        var invalidNumberOfTerms = -1;

        // Act and Assert
        Action act = () => ConcurrentComputationLibrary.CalculatePi(invalidNumberOfTerms);
        act.Should().Throw<OverflowException>().WithMessage("Arithmetic operation resulted in an overflow.");
    }

}