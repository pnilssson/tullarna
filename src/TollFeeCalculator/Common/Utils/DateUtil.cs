namespace TollFeeCalculator.Common.Utils;

public static class DateUtil
{
    
    /// <summary>
    /// Validates that all provided dates is within the same day.
    /// </summary>
    /// <param name="dates">Dates to validate.</param>
    /// <exception cref="ArgumentException">Throws if dates contains dates of different days.</exception>
    public static void ValidateDatesIsFromSameDay(IEnumerable<DateTime> dates)
    {
        if (dates.GroupBy(date => date.Date).Count() > 1)
            throw new ArgumentException("Dates must be from the same day.");
    }
}