using TollFeeCalculator.Common.Enums;
using TollFeeCalculator.Common.Interfaces;

namespace TollFeeCalculator.Models.Vehicles;

public sealed class Motorbike : Vehicle, ITollFreeVehicle
{
    public TollFreeVehicleType TollFreeVehicleType => TollFreeVehicleType.Motorbike;

    public Motorbike(TollFreeType tollFreeType)
    {
        TollFreeType = tollFreeType;
    }

    public Motorbike()
    {
    }

    public override bool IsTollFree() => true;
}
