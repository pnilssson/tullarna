namespace TollFeeCalculator.Common.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// Checks if a the TimeOfDay of a DateTime is between two time of days.
    /// </summary>
    /// <param name="dateTime">Time to compare with start and end time.</param>
    /// <param name="startTime">Start time.</param>
    /// <param name="endTime">End time.</param>
    /// <returns>True if the TimeOfDay of the dateTime parameter is between startTime and endTime.</returns>
    public static bool IsBetween(this DateTime dateTime, TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime == endTime)
            throw new ArgumentException("Start time and end time must differ.");
        
        var time = dateTime.TimeOfDay;
        
        // If start time is less or equal to end time it means the two time spans is on the same day
        if (startTime <= endTime)
        {
            // Return true if the time is between start and end time
            return time >= startTime && time <= endTime;
        }
        // Otherwise the two time spans is on different days
        return time >= startTime || time <= endTime;
    }
}