using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public class Car : Vehicle
{
    public Car(TollFreeVehicle tollFreeVehicleType)
    {
        TollFreeVehicleType = tollFreeVehicleType;
    }

    public Car()
    {
    }
}