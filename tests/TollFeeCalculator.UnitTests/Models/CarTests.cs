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
    
    [Fact]
    public void TollFreeType_WhenInstantiatedWith_DefaultConstructor_Should_BeNull()
    {
        // Arrange
        var car = new Car();

        // Act
        var tollFreeType = car.TollFreeType;

        // Assert
        tollFreeType.Should().Be(null);
    }
    
    [Theory]
    [InlineData(TollFreeType.Military)]
    [InlineData(TollFreeType.Emergency)]
    [InlineData(TollFreeType.Diplomat)]
    [InlineData(TollFreeType.Foreign)]
    public void TollFreeType_WhenInstantiatedWith_ParameterizedConstructor_Should_ReturnTollFreeType(TollFreeType tollFreeTypeInput)
    {
        // Arrange
        var car = new Car(tollFreeTypeInput);

        // Act
        var tollFreeType = car.TollFreeType;

        // Assert
        tollFreeType.Should().Be(tollFreeTypeInput);
    }
}