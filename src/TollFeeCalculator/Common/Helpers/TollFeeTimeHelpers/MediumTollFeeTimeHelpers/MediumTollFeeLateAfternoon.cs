using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers.MediumTollFeeTimeHelpers;

public class MediumTollFeeLateAfternoon : TollFeeTime
{
    protected override TimeSpan StartTime => new(17, 0, 0);
    protected override TimeSpan EndTime => new(17, 59, 0);
    protected override int TollFee => TollFeeConstants.Medium;
}