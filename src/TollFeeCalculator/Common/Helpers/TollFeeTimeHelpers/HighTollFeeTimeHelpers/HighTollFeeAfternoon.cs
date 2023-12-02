using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers.HighTollFeeTimeHelpers;

public class HighTollFeeAfternoon : TollFeeTime
{
    protected override TimeSpan StartTime => new(15, 30, 0);
    protected override TimeSpan EndTime => new(16, 59, 0);
    protected override int TollFee => TollFeeConstants.High;
}