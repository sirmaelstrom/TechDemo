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
    
    // To-do:  address timeout issues
    [Fact]
    public void GeneratePrimes_ShouldGenerateCorrectNumberOfPrimes()
    {
        // Arrange
        int numberOfPrimesToGenerate = 10;
        int timeoutMilliseconds = 5000; // Set a timeout (e.g., 5 seconds)

        // Act
        var generateTask = Task.Run(() =>
        {
            return IntegerLibrary.GeneratePrimes(numberOfPrimesToGenerate, timeoutMilliseconds)
                .Take(numberOfPrimesToGenerate)
                .ToList();
        });

        bool completed = generateTask.Wait(timeoutMilliseconds);

        // Assert
        completed.Should().BeTrue("the task should complete within the timeout");

        if (completed)
        {
            var primes = generateTask.Result;
            primes.Should().HaveCount(numberOfPrimesToGenerate);
        }
    }

    // To-do:  address timeout issues
    [Fact]
    public void GeneratePrimes_ShouldGenerateValidPrimes()
    {
        // Arrange
        int numberOfPrimes = 10;
        int timeoutMilliseconds = 5000; // Set a timeout (e.g., 5 seconds)

        // Act
        var primes = IntegerLibrary.GeneratePrimes(numberOfPrimes, timeoutMilliseconds);

        // Assert
        primes.Should().OnlyContain(x => _sut.IsPrime(x));
    }

    [Fact]
    public void GeneratePrimes_ShouldThrowArgumentException_WithInvalidNumberOfPrimes()
    {
        // Arrange
        int invalidNumberOfPrimes = 0;
        int timeoutMilliseconds = 5000; // Set a timeout (e.g., 5 seconds)

        // Act and Assert
        Action act = () => IntegerLibrary.GeneratePrimes(invalidNumberOfPrimes, timeoutMilliseconds);
        act.Should().Throw<ArgumentException>().WithMessage("Number of primes must be greater than or equal to 1.");
    }
    
}