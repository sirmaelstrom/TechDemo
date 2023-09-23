using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class PeanoIntegerLibraryTests
{
    [Fact]
    public void IsZero_ShouldReturnTrue_WhenZero()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();

        // Act & Assert
        zero.IsZero().Should().BeTrue();
    }

    [Fact]
    public void ToInt_ShouldReturnZero_WhenZero()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();

        // Act & Assert
        zero.ToInt().Should().Be(0);
    }

    [Fact]
    public void Add_ShouldReturnOther_WhenAddingZero()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);

        // Act
        var result = zero.Add(one);

        // Assert
        result.Should().Be(one);
    }

    [Fact]
    public void Subtract_ShouldThrowException_WhenSubtractingZero()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);

        // Act & Assert
        zero.Invoking(z => z.Subtract(one)).Should().Throw<InvalidOperationException>()
            .WithMessage("Subtraction would result in a negative number.");
    }

    [Fact]
    public void IsZero_ShouldReturnFalse_WhenSuccessor()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);

        // Act & Assert
        one.IsZero().Should().BeFalse();
    }

    [Fact]
    public void Predecessor_ShouldThrowException_WhenZero()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();

        // Act & Assert
        zero.Invoking(z => z.Predecessor()).Should().Throw<InvalidOperationException>()
            .WithMessage("Zero has no predecessor.");
    }

    [Fact]
    public void Predecessor_ShouldReturnZero_WhenSuccessor()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);

        // Act & Assert
        one.Predecessor().Should().Be(zero);
    }

    [Fact]
    public void Add_ShouldAddPredecessor_WhenSuccessor()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);
        var two = new PeanoIntegerLibrary.Succ(one);

        // Act
        var result = one.Add(two);

        // Assert
        result.ToInt().Should().Be(two.Successor().ToInt());
    }


    [Fact]
    public void Predecessor_ShouldReturnOne_WhenTwo()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);
        var two = new PeanoIntegerLibrary.Succ(one);

        // Act & Assert
        two.Predecessor().Should().Be(one);
    }
    
    [Fact]
    public void Subtract_ShouldSubtractPredecessor_WhenSuccessor()
    {
        // Arrange
        var zero = new PeanoIntegerLibrary.Zero();
        var one = new PeanoIntegerLibrary.Succ(zero);
        var two = new PeanoIntegerLibrary.Succ(one);

        // Act
        var result = two.Subtract(one);

        // Assert
        result.Should().Be(one);
    }
}