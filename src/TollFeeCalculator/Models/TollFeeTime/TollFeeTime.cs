using TollFeeCalculator.Common.Extensions;

namespace TollFeeCalculator.Models.TollFeeTime;

public abstract class TollFeeTime
{
    protected abstract TimeSpan StartTime { get; }
    protected abstract TimeSpan EndTime { get; }
    protected abstract int TollFee { get; }
    public int GetTollFee(DateTime date) => date.IsBetween(StartTime, EndTime) ? TollFee : 0;
}