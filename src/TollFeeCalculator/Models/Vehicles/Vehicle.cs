using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public abstract class Vehicle
{
    protected TollFreeVehicle? TollFreeVehicleType = null;

    public bool IsTollFreeVehicle() => TollFreeVehicleType is not null;
}
