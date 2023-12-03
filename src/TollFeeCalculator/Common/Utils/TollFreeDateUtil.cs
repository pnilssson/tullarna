using TollFeeCalculator.Common.Interfaces;
using TollFeeCalculator.Data;
using TollFeeCalculator.Models.TollFreeDate;

namespace TollFeeCalculator.Common.Utils;

public static class TollFreeDateUtil
{
    private const int MonthNumberOfJuly = 7;
    private static readonly IEnumerable<IIsTollFreeDate> TollFreeDates;

    static TollFreeDateUtil()
    {
        TollFreeDates = GetTollFreeDates();
    }

    public static bool IsTollFreeDate(DateTime date)
    {
        ValidateValidYear(date.Year);
        
        return IsWeekend(date) || IsJuly(date) || TollFreeDates.Any(tollFreeDate => tollFreeDate.IsTollFreeDate(date));
    }

    private static void ValidateValidYear(int dateYear)
    {
        if (!TollFreeDateData.ValidYears.Contains(dateYear))
            throw new ArgumentException("Date with invalid year provided for TollFreeDateUtil.IsTollFreeDate method.");
    }

    private static bool IsWeekend(DateTime date) =>
        date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    
    private static bool IsJuly(DateTime date) => date.Month is MonthNumberOfJuly;
    
    private static IEnumerable<IIsTollFreeDate> GetTollFreeDates() => 
        TollFreeDateData.Dates().Select(date => new TollFreeDate(date));
}