using FluentAssertions;
using TollFeeCalculator.Common.Utils;

namespace TollFeeCalculator.UnitTests.UtilTests;

public class TollFeeTimeUtilTests
{
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
        var date = DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute);

        // Act
        var tollFee = TollFeeTimeUtil.GetTollFee(date);

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
        var date = DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute);

        // Act
        var tollFee = TollFeeTimeUtil.GetTollFee(date);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
    
    [Theory]
    [InlineData(7, 0)]
    [InlineData(7, 59)]
    [InlineData(15, 30)]
    [InlineData(16, 15)]
    [InlineData(16, 59)]
    public void GetTollFee_OnHighTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 18;
        var date = DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute);

        // Act
        var tollFee = TollFeeTimeUtil.GetTollFee(date);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
    
    [Theory]
    [InlineData(18, 30)]
    [InlineData(24, 0)]
    [InlineData(5, 59)]
    public void GetTollFee_OnNonTollFeeTimes_Should_ReturnCorrectTollFee(int hour, int minute)
    {
        // Arrange
        const int expectedTollFee = 0;
        var date = DateUtils.GetNonTollFreeDate().AddHours(hour).AddMinutes(minute);

        // Act
        var tollFee = TollFeeTimeUtil.GetTollFee(date);

        // Assert
        tollFee.Should().Be(expectedTollFee);
    }
}