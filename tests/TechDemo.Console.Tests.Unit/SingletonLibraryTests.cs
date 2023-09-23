using FluentAssertions;
using TechDemo.Console.Libraries;
using Xunit;

namespace TechDemo.Console.Tests.Unit;

public class SingletonLibraryTests
{
    [Fact]
    public void SingletonGetInstance_ShouldReturnSameInstance_WhenInvoked()
    {
        // Arrange
        var sut = SingletonLibrary.Instance;
        var mySingleton = SingletonLibrary.Instance;
        
        // Act
        var sutSingletonGuid = sut.GetGuid();
        var mySingletonGuid = mySingleton.GetGuid();
        
        // Assert
        sutSingletonGuid.Should().Be(mySingletonGuid);
        sut.Should().BeEquivalentTo(mySingleton);
    }
    
}