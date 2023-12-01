using FluentAssertions;
using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator.UnitTests.Models;

public class MotorbikeTests
{
    [Fact]
    public void IsTollFree_Should_ReturnTrue()
    {
        // Arrange
        var motorbike = new Motorbike();

        // Act
        var tollFree = motorbike.IsTollFree();

        // Assert
        tollFree.Should().BeTrue();
    }
    
    [Fact]
    public void TollFreeVehicleType_Should_BeMotorbike()
    {
        // Arrange
        var motorbike = new Motorbike();

        // Act
        var vehicleType = motorbike.TollFreeVehicleType;

        // Assert
        vehicleType.Should().Be(TollFreeVehicleType.Motorbike);
    }
    
    [Fact]
    public void TollFreeType_WhenInstantiatedWith_DefaultConstructor_Should_BeNull()
    {
        // Arrange
        var motorbike = new Motorbike();

        // Act
        var tollFreeType = motorbike.TollFreeType;

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
        var motorbike = new Motorbike(tollFreeTypeInput);

        // Act
        var tollFreeType = motorbike.TollFreeType;

        // Assert
        tollFreeType.Should().Be(tollFreeTypeInput);
    }
}