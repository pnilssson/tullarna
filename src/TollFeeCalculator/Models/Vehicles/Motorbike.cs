namespace TollFeeCalculator.Models.Vehicles;

public class Motorbike : Vehicle
{
    public override bool IsTollFree() => true;
}
