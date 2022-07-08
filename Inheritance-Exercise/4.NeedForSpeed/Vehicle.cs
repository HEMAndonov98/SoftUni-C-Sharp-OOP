using System;
namespace NeedForSpeed
{
	public class Vehicle
	{
		private double _defaultFuelConsumption;
		private double _fuelConsumption;
		private double _fuel;
		private int _horsePower;


		public Vehicle(int horsePower, double fuel)
		{
			this.HorsePower = horsePower;
			this.Fuel = fuel;
			this.FuelConsumption = this.DefaultFuelConsumption = 1.25;
		}

        public double DefaultFuelConsumption { get { return this._defaultFuelConsumption; } set { this._defaultFuelConsumption = value; } }
        public virtual double FuelConsumption { get { return this._fuelConsumption; } set { this._fuelConsumption = value; } }
        public double Fuel { get { return this._fuel; } set { this._fuel = value; } }
        public int HorsePower { get { return this._horsePower; } set { this._horsePower = value; } }

		public virtual void Drive(double kilomiteres)
        {
			this._fuel -= kilomiteres * this.FuelConsumption;
        }

    }
}

