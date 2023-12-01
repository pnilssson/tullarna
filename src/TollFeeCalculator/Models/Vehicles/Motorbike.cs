using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public class Motorbike : Vehicle
{
    public Motorbike()
    {
        TollFreeVehicleType = TollFreeVehicle.Motorbike;
    }
}
