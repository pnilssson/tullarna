using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Models.TollFeeTime.MediumTollFeeTime;

public sealed class MediumTollFeeLateMorning : TollFeeTime
{
    protected override TimeSpan StartTime => new(8, 0, 0);
    protected override TimeSpan EndTime => new(8, 29, 0);
    protected override int TollFee => TollFeeConstants.Medium;
}