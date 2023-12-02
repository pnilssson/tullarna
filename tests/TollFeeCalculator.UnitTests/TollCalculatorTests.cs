using FluentAssertions;
using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator.UnitTests;

public class TollCalculatorTests
{
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
    
    [Theory]
    [InlineData(6, 0)]
    [InlineData(6, 29)]
    [InlineData(8, 30)]
    [InlineData(11, 15)]
    [InlineData(14, 59)]
    [InlineData(18, 0)]
    [InlineData(18, 29)]
    public void GetTollFee_OnLowTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 8;
        var car = new Car();
        var dates = new[]
            { DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute) };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
    
    [Theory]
    [InlineData(6, 30)]
    [InlineData(6, 59)]
    [InlineData(8, 0)]
    [InlineData(8, 29)]
    [InlineData(15, 0)]
    [InlineData(15, 29)]
    [InlineData(17, 0)]
    [InlineData(17, 59)]
    public void GetTollFee_OnMediumTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 13;
        var car = new Car();
        var dates = new[]
            { DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute) };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
    
    [Theory]
    [InlineData(7, 0)]
    [InlineData(7, 59)]
    [InlineData(15, 30)]
    [InlineData(16, 15)]
    [InlineData(16, 59)]
    public void GetTollFee_OnTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 18;
        var car = new Car();
        var dates = new[]
            { DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute) };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
    
    [Theory]
    [InlineData(18, 30)]
    [InlineData(5, 59)]
    public void GetTollFee_OnNonTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 0;
        var car = new Car();
        var dates = new[]
            { DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute) };

        // Act
        var tollFee = TollCalculator.GetTollFee(car, dates);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
}