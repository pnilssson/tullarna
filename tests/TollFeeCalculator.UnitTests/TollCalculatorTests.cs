using FluentAssertions;
using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator.UnitTests;

public class TollCalculatorTests
{
    [Fact]
    public void GetTollFee_WithDifferentDays_Should_Throw_ArgumentException()
    {
        // Arrange
        var car = new Car();
        var dateOne = DateUtils.GetNonTollFreeDateAndTime();
        var dateTwo = DateUtils.GetNonTollFreeDateAndTime().AddDays(1);
        
        var dates = new[]
            { dateOne, dateTwo };

        // Act
        Action tollFee = () => TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Dates must be from the same day.");
    }
    
    [Fact]
    public void GetTollFee_OnMotorbike_Should_NotReturnFee()
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
    public void GetTollFee_OnCar_Should_ReturnFee()
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
    
    [Theory]
    [InlineData(TollFreeType.Military)]
    [InlineData(TollFreeType.Emergency)]
    [InlineData(TollFreeType.Diplomat)]
    [InlineData(TollFreeType.Foreign)]
    public void GetTollFee_OnTollFreeCar_Should_NotReturnFee(TollFreeType tollFreeType)
    {
        // Arrange
        var car = new Car(tollFreeType);
        var dates = new[]
            { DateUtils.GetNonTollFreeDateAndTime() };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(0);
    }
}