using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Models.TollFeeTime.MediumTollFeeTime;

public sealed class MediumTollFeeAfternoon : TollFeeTime
{
    protected override TimeSpan StartTime => new(15, 0, 0);
    protected override TimeSpan EndTime => new(15, 29, 0);
    protected override int TollFee => TollFeeConstants.Medium;
}