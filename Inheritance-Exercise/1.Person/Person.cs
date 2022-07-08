using System;
namespace Person
{
	public class Person
	{
		private string _name;
		private int _age;

		public Person(string name, int age)
		{
            this.Name = name;
            this.Age = age;
		}

        public string Name { get { return _name; } set { this._name = value; } }
        public int Age { get { return _age; } set
            {
                if (value > 0)
                {
                    this._age = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}"; 
        }

    }
}

