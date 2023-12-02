using TollFeeCalculator.Common.Constants;

namespace TollFeeCalculator.Common.Helpers.TollFeeTimeHelpers.MediumTollFeeTimeHelpers;

public class MediumTollFeeMorning : TollFeeTime
{
    protected override TimeSpan StartTime => new(6, 30, 0);
    protected override TimeSpan EndTime => new(6, 59, 0);
    protected override int TollFee => TollFeeConstants.Medium;
}