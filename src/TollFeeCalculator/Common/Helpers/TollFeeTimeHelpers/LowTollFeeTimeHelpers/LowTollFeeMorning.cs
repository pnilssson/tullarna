using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers.LowTollFeeTimeHelpers;

public class LowTollFeeMorning : TollFeeTime
{
    protected override TimeSpan StartTime => new(6, 0, 0);
    protected override TimeSpan EndTime => new(6, 29, 0);
    protected override int TollFee => TollFeeConstants.Low;
}