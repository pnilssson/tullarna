using FluentAssertions;
using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator.UnitTests;

public class TollCalculatorTests
{
    [Fact]
    public void GetTollFee_OnMotorbike_ShouldNotPayTollFee()
    {
        // Arrange
        var motorbike = new Motorbike();
        var dates = new[]
            { DateUtils.GetNonTollFreeDateAndTime() };

        // Act
        var tollFee = TollCalculator.GetTollFee(motorbike, dates);

        // Assert
        tollFee.Should().Be(0);
    }
    
    [Fact]
    public void GetTollFee_OnCar_ShouldPayTollFee()
    {
        // Arrange
        var car = new Car();
        var dates = new[]
            { DateUtils.GetNonTollFreeDateAndTime() };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().NotBe(0);
    }
    
    [Fact]
    public void GetTollFee_OnTollFreeCar_ShouldNotPayTollFee()
    {
        // Arrange
        var car = new Car(TollFreeVehicle.Military);
        var dates = new[]
            { DateUtils.GetNonTollFreeDateAndTime() };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(0);
    }
}