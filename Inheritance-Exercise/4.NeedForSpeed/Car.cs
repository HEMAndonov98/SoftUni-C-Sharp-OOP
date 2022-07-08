using System;
namespace NeedForSpeed
{
	public class Car : Vehicle
	{
		public Car(int horsePower, double fuel) : base(horsePower, fuel)
		{
			base.FuelConsumption = base.DefaultFuelConsumption = 3;
		}
	}
}

