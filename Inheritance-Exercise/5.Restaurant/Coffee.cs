using System;
namespace Restaurant
{
	public class Coffee : HotBeverage
	{
		public Coffee(string name, double cafeine) : base(name, 3.50m, 50)
		{
			this.Cafeine = cafeine;
		}
        public double Cafeine { get; set; }
    }
}

