using FluentAssertions;
using System.Collections;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class StringManipulationLibraryTests
{
    private readonly StringManipulationLibrary _sut = new();
    
    [Theory]
    [InlineData("aBcD", "ac")]
    [InlineData("1234", "13")]
    public void EveryOther_ShouldReturnEveryOtherCharacter_WhenStringIsValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.EveryOther(input);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Theory]
    [InlineData("aBcD", "DB")]
    [InlineData("1234", "42")]
    public void EveryOtherRevers_ShouldReturnEveryOtherCharacterInReverse_WhenStringIsValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.EveryOtherReverse(input);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [MemberData(nameof(GenerateSubStringsData))]
    public void GenerateSubStrings_ShouldGenerateSubStrings_WhenInputIsValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.GenerateSubstrings(input);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [MemberData(nameof(GenerateSubStringsData))]
    public void GenerateSubStringsManualPreIncrement_ShouldGenerateSubStrings_WhenInputIsValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.GenerateSubstringsManualPreIncrement(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> GenerateSubStringsData =>
        new List<object[]>
        {
            new object[] { "1234", "1 12 123 1234 2 23 234 3 34 4" },
            new object[] { "test", "t te tes test e es est s st t" }
        };

    [Theory]
    [ClassData(typeof(ReverseStringTestData))]
    public void ReversString_ShouldReverseString_WhenInputValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.ReverseString(input);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(ReverseStringTestData))]
    public void ReversStringWithStringBuilder_ShouldReverseString_WhenInputValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.ReverseStringWithStringBuilder(input);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(ReverseStringTestData))]
    public void ReversStringLinq_ShouldReverseString_WhenInputValid(string input, string expectedResult)
    {
        // Act
        var result = _sut.ReverseStringLinq(input);

        // Assert
        result.Should().Be(expectedResult);
    }
}

public class ReverseStringTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "justin", "nitsuj" };
        yield return new object[] { "abcdefghijklmnopqrstuvwxyz", "zyxwvutsrqponmlkjihgfedcba" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}