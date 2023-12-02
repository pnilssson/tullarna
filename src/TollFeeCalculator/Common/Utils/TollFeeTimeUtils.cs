using TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers;

namespace TollFeeCalculator.Common.Utils;

public static class TollFeeTimeUtils
{
    private static readonly IEnumerable<TollFeeTime?> TollFeeTimes;
    
    static TollFeeTimeUtils()
    {
        TollFeeTimes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(TollFeeTime)))
            .Select(type => Activator.CreateInstance(type) as TollFeeTime);
    }

    /// <summary>
    /// Loops through all sub classes of TollFeeTime and calls the GetTollFee, returns fee on first match otherwise returns 0. 
    /// </summary>
    /// <param name="date">DateTime to check for tull fees.</param>
    /// <returns>The tull fee for the provided date time.</returns>
    public static int GetTollFee(DateTime date)
    {
        foreach (var tollFeeTime in TollFeeTimes)
        {
            if (tollFeeTime is null) continue;
            var tollFee = tollFeeTime.GetTollFee(date);
            
            if (tollFee > 0)
                return tollFee;
        }

        return 0;
    }
}