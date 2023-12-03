using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Models.TollFeeTime.LowTollFeeTime;

public class LowTollFeeMorning : TollFeeTime
{
    protected override TimeSpan StartTime => new(6, 0, 0);
    protected override TimeSpan EndTime => new(6, 29, 0);
    protected override int TollFee => TollFeeConstants.Low;
}