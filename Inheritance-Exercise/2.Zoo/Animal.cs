using System;
namespace Zoo
{
	public class Animal
	{
		private string _name;

		public Animal(string name)
		{
			this.Name = name;
		}

        public string Name { get { return this._name; } set { this._name = value; } }
    }
}

