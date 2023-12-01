using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Common.Interfaces;

namespace TollFeeCalculator.Models.Vehicles;

public class Motorbike : Vehicle, ITollFreeVehicle
{
    public TollFreeVehicleType TollFreeVehicleType { get; private init; } = TollFreeVehicleType.Motorbike;

    public Motorbike(TollFreeType tollFreeType)
    {
        TollFreeType = tollFreeType;
    }

    public Motorbike()
    {
    }

    public override bool IsTollFree() => true;
}
