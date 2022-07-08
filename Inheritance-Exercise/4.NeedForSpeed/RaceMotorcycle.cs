using System;

namespace NeedForSpeed
{
	public class RaceMotorcycle : Motorcycle
	{
		public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
		{
			base.FuelConsumption = base.DefaultFuelConsumption = 8;
		}
	}
}

