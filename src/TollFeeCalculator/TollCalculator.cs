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
        DateUtil.ValidateDatesIsFromSameDay(dates);

        // As we validate that all provided dates is from the same day we can return early if any date IsTollFreeDate
        if (vehicle.IsTollFree() || TollFreeDateUtil.IsTollFreeDate(dates[0]))
            return 0;
        
        var fee = GetTollFee(dates);

        return ExceedsMaxFee(fee) ? TollFeeConstants.Max : fee;
    }

    private static int GetTollFee(DateTime[] dates)
    {
        int totalFee = 0;
        // Order dates by time of day to be able to see which dates are within a one hour time slot
        // and when to start a new one hour time slot
        dates = dates.OrderBy(date => date.TimeOfDay).ToArray();
        // First date within the current one hour time slot
        DateTime intervalStart = dates[0];
        int currentIntervalHighestFee = TollFeeTimeUtil.GetTollFee(intervalStart);
        foreach (DateTime date in dates)
        {
            int currentFee = TollFeeTimeUtil.GetTollFee(date);

            // Proceed to next date if currentFee is 0
            if (currentFee == 0)
                continue;

            var diffInMinutes = (date - intervalStart).TotalMinutes;
            // If current date is within 60 minutes of the intervalStart date
            if (diffInMinutes <= 60)
            {
                // If total fee is bigger then 0 we subtract the currentIntervalHighestFee from it
                // to make sure that we dont add fees multiple times within one interval
                if (totalFee > 0) totalFee -= currentIntervalHighestFee;
                // If currentFee is bigger or equal to currentIntervalHighestFee then we set currentIntervalHighestFee to currentFee
                // to always add the highest fee during the interval
                if (currentFee >= currentIntervalHighestFee) currentIntervalHighestFee = currentFee;
                totalFee += currentIntervalHighestFee;
            }
            else
            {
                // The 60 minutes time slot has been exceeded and we need to start a new one
                intervalStart = date;
                // The new intervals highest fee will be the current one
                currentIntervalHighestFee = currentFee;
                // Add current fee to totalFee
                totalFee += currentFee;
            }
        }

        return totalFee;
    }

    private static bool ExceedsMaxFee(int amount) => amount > TollFeeConstants.Max;
}