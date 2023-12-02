using TollFeeCalculator.Common.Constants;
using TollFeeCalculator.Common.Extensions;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers;

public abstract class TollFeeTime
{
    protected abstract TimeSpan StartTime { get; }
    protected abstract TimeSpan EndTime { get; }
    protected abstract int TollFee { get; }
    public int GetTollFee(DateTime date) => date.IsBetween(StartTime, EndTime) ? TollFee : 0;
}