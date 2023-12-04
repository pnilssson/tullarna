using FluentAssertions;
using TollFeeCalculator.Common.Utils;

namespace TollFeeCalculator.UnitTests.Tests.UtilTests;

public class TollFreeDateUtilTests
{
    [Fact]
    public void IsTollFreeDate_WithInvalidYear_Should_Throw_ArgumentException()
    {
        // Arrange
        var date = DateUtils.GetNonTollFreeDateAndTime().AddYears(1);

        // Act
        Action tollFee = () => TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        tollFee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Date with invalid year provided for TollFreeDateUtil.IsTollFreeDate method.");
    }
    
    [Fact]
    public void IsTollFreeDate_InJuly_Should_ReturnTrue()
    {
        // Arrange
        const int year = 2023;
        const int july = 7;
        const int day = 1;
        var date = new DateTime(year, july, day);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeTrue();
    }
        
    [Fact]
    public void IsTollFreeDate_OnSaturday_Should_ReturnTrue()
    {
        // Arrange
        const int year = 2023;
        const int january = 1;
        const int firstSaturdayInJanuary = 7;
        var date = new DateTime(year, january, firstSaturdayInJanuary);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeTrue();
    }
    
    [Fact]
    public void IsTollFreeDate_OnSunday_Should_ReturnTrue()
    {
        // Arrange
        const int year = 2023;
        const int january = 1;
        const int firstSundayInJanuary = 8;
        var date = new DateTime(year, january, firstSundayInJanuary);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 6)]
    [InlineData(4, 7)]
    [InlineData(4, 9)]
    [InlineData(4, 10)]
    [InlineData(5, 1)]
    [InlineData(5, 18)]
    [InlineData(5, 28)]
    [InlineData(6, 6)]
    [InlineData(6, 24)]
    [InlineData(11, 4)]
    [InlineData(12, 25)]
    [InlineData(12, 26)]
    public void IsTollFreeDate_OnPublicHoliday_Should_ReturnTrue(int month, int day)
    {
        // Arrange
        const int year = 2023;
        var date = new DateTime(year, month, day);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1, 5)]
    [InlineData(4, 6)]
    [InlineData(4, 8)]
    [InlineData(4, 9)]
    [InlineData(4, 30)]
    [InlineData(5, 17)]
    [InlineData(5, 27)]
    [InlineData(6, 5)]
    [InlineData(6, 23)]
    [InlineData(11, 3)]
    [InlineData(12, 24)]
    [InlineData(12, 25)]
    public void IsTollFreeDate_OnDayBeforePublicHoliday_Should_ReturnTrue(int month, int day)
    {
        // Arrange
        const int year = 2023;
        var date = new DateTime(year, month, day);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1, 4)]
    [InlineData(3, 13)]
    [InlineData(6, 8)]
    [InlineData(9, 22)]
    [InlineData(12, 4)]
    public void IsTollFreeDate_OnNonTollFreeDate_Should_ReturnFalse(int month, int day)
    {
        // Arrange
        const int year = 2023;
        var date = new DateTime(year, month, day);

        // Act
        var isTollFreeDate = TollFreeDateUtil.IsTollFreeDate(date);

        // Assert
        isTollFreeDate.Should().BeFalse();
    }
}