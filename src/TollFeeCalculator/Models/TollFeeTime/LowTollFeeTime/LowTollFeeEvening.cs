using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Models.TollFeeTime.LowTollFeeTime;

public sealed class LowTollFeeEvening : TollFeeTime
{
    protected override TimeSpan StartTime => new(18, 00, 0);
    protected override TimeSpan EndTime => new(18, 29, 0);
    protected override int TollFee => TollFeeConstants.Low;
}