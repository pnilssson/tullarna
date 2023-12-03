using TollFeeCalculator.Common.Constants;
using TollFeeCalculator.Common.Utils;
using TollFeeCalculator.Models.Vehicles;

namespace TollFeeCalculator;

public static class TollCalculator
{
    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */
    public static int GetTollFee(Vehicle vehicle, DateTime[] dates)
    {
        ValidateDatesIsFromSameDay(dates);

        // As we validate that all provided dates is from the same day we can return early if any date IsTollFreeDate
        if (vehicle.IsTollFree() || TollFreeDateUtil.IsTollFreeDate(dates[0]))
            return 0;
        
        // Sortera datum på tid
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = TollFeeTimeUtil.GetTollFee(date);
            int tempFee = TollFeeTimeUtil.GetTollFee(intervalStart);

            long diffInMilliseconds = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMilliseconds/1000/60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        
        return ExceedsMaxFee(totalFee) ? TollFeeConstants.Max : totalFee;
    }

    private static bool ExceedsMaxFee(int amount) => amount > TollFeeConstants.Max;

    /// <summary>
    /// Validates that all provided dates is within the same day.
    /// </summary>
    /// <param name="dates">Dates to validate.</param>
    /// <exception cref="ArgumentException">Throws if dates contains dates of different days.</exception>
    private static void ValidateDatesIsFromSameDay(IEnumerable<DateTime> dates)
    {
        if (dates.GroupBy(date => date.Day).Count() > 1)
            throw new ArgumentException("Dates must be from the same day.");
    }
}