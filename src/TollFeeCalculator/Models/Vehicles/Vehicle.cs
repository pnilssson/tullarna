using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public abstract class Vehicle
{
    public TollFreeType? TollFreeType { get; protected init; }

    public abstract bool IsTollFree();
}
