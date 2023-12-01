using FluentAssertions;
using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator.UnitTests.Models;

public class CarTests
{
    [Fact]
    public void IsTollFree_WhenInstantiatedWith_DefaultConstructor_Should_ReturnFalse()
    {
        // Arrange
        var car = new Car();

        // Act
        var tollFree = car.IsTollFree();

        // Assert
        tollFree.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(TollFreeType.Military)]
    [InlineData(TollFreeType.Emergency)]
    [InlineData(TollFreeType.Diplomat)]
    [InlineData(TollFreeType.Foreign)]
    public void IsTollFree_WhenInstantiatedWith_ParameterizedConstructor_Should_ReturnTrue(TollFreeType tollFreeType)
    {
        // Arrange
        var car = new Car(tollFreeType);

        // Act
        var tollFree = car.IsTollFree();

        // Assert
        tollFree.Should().BeTrue();
    }
}