namespace TollFeeCalculator.UnitTests;

public static class DateUtils
{
    public static DateTime GetNonTollFreeDateAndTime()
    {
        var date = GetNonTollFreeDate();
        return date.AddHours(6);
    }
        
    public static DateTime GetNonTollFreeDate()
    {
        return new DateTime(2013, 01, 02);
    }
}