using System;
using System.Collections.Generic;

namespace CustomRandomList
{
	public class RandomList : List<string>
	{
		public string RandomString()
        {
			var rng = new Random();

			var indexOfRemoving = rng.Next(0, this.Count);
			string value = this[indexOfRemoving];
			base.RemoveAt(indexOfRemoving);
			return value;
        }
	}
}

