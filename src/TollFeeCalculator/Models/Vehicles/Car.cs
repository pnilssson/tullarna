﻿using TollFeeCalculator.Common.Enums;

namespace TollFeeCalculator.Models.Vehicles;

public sealed class Car : Vehicle
{
    public Car(TollFreeType tollFreeType)
    {
        TollFreeType = tollFreeType;
    }

    public Car()
    {
    }

    public override bool IsTollFree() => TollFreeType is not null;
}