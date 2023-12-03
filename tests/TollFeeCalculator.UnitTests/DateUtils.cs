namespace TollFeeCalculator.UnitTests;

public static class DateUtils
{
    public static DateTime GetNonTollFreeDateAndTime()
    {
        return GetNonTollFreeDate().AddHours(6);
    }
    
    public static DateTime GetNonTollFreeDate()
    {
        return new DateTime(2013, 01, 02);
    }
    
    public static DateTime GetTollFreeDateWithNonTollFreeTime()
    {
        return GetTollFreeDate().AddHours(6);
    }

    public static DateTime[] GetDateTimesThatExceedsDailyMaxFee()
    {
        return new[]
        {
            // 18
            GetNonTollFreeDate().AddHours(7),
            // 13
            GetNonTollFreeDate().AddHours(8).AddMinutes(15),
            // 18
            GetNonTollFreeDate().AddHours(15).AddMinutes(30),
            // 13
            GetNonTollFreeDate().AddHours(17),
        };
    }
    
    public static (DateTime[] dates, int sum) GetDateTimesWithMoreThenOneHourApartAndTollFeeSum()
    {
        return (new[]
        {
            // 18
            GetNonTollFreeDate().AddHours(7),
            // 13
            GetNonTollFreeDate().AddHours(17),
        }, 31);
    }
    
    public static (DateTime[] dates, int highestFee) GetDateTimesWithinOneHourAndHighestFee()
    {
        return (new[]
        {
            // 8
            GetNonTollFreeDate().AddHours(6).AddMinutes(29),
            // 13
            GetNonTollFreeDate().AddHours(6).AddMinutes(30),
            // 18
            GetNonTollFreeDate().AddHours(7)
        }, 18);
    }
    
    public static (DateTime[] dates, int sum) GetDateTimesWithinDifferentOneHourTimeSlotsAndFeeSum()
    {
        return (new[]
        {
            // First 1 hour time slot
            // 8
            GetNonTollFreeDate().AddHours(6),
            // 13
            GetNonTollFreeDate().AddHours(6).AddMinutes(30),
            // Second 1 hour time slot
            // 13
            GetNonTollFreeDate().AddHours(17).AddMinutes(30),
            // 8
            GetNonTollFreeDate().AddHours(18),
        }, 26);
    }
    
    private static DateTime GetTollFreeDate()
    {
        return new DateTime(2013, 01, 05);
    }
}