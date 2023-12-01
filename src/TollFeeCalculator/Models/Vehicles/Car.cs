using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public class Car : Vehicle
{
    private readonly TollFreeType? _tollFreeType;
    
    public Car(TollFreeType tollFreeVehicleType)
    {
        _tollFreeType = tollFreeVehicleType;
    }

    public Car()
    {
    }

    public override bool IsTollFree() => _tollFreeType is not null;
}