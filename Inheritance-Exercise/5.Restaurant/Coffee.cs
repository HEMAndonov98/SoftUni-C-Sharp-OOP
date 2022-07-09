using System;
namespace Restaurant
{
	public class Coffee : HotBeverage
	{
		public Coffee(string name, double cafeine) : base(name, 3.50m, 50)
		{
			this.Caffeine = cafeine;
		}
        public double Caffeine { get; set; }
    }
}

