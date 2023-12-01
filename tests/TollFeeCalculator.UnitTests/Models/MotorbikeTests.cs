using FluentAssertions;
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
}