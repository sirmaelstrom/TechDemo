using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class FibonacciLibraryTests
{
    public class FibonacciClosureTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        [InlineData(8, 34)]
        [InlineData(9, 55)]
        public void FibonacciClosure_ShouldReturnExpected_WhenInputIs(int input, int expectedResult)
        {
            // Arrange 
            Func<int> sut = FibonacciLibrary.CreateFibonacciClosure();

            // Act
            var result = GetNFibonacciNumber(sut, input);

            // Assert
            result.Should().Be(expectedResult);
        }

        private static int GetNFibonacciNumber(Func<int> fibonacci, int n)
        {
            int result = 0;
            for (int i = 0; i <= n; i++)
            {
                result = fibonacci();
            }
            return result;
        }
    }
}