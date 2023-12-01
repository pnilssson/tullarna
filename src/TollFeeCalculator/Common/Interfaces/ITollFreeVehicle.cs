using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Common.Interfaces;

public interface ITollFreeVehicle
{
    TollFreeVehicleType TollFreeVehicleType { get; }
}