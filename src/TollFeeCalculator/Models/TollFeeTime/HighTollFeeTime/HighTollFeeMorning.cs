using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Models.TollFeeTime.HighTollFeeTime;

public sealed class HighTollFeeMorning : TollFeeTime
{
    protected override TimeSpan StartTime => new(7, 0, 0);
    protected override TimeSpan EndTime => new(7, 59, 0);
    protected override int TollFee => TollFeeConstants.High;
}