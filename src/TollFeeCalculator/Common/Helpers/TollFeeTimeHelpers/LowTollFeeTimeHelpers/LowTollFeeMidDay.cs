using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers.LowTollFeeTimeHelpers;

public class LowTollFeeMidDay : TollFeeTime
{
    protected override TimeSpan StartTime => new(8, 30, 0);
    protected override TimeSpan EndTime => new(14, 59, 0);
    protected override int TollFee => TollFeeConstants.Low;
}