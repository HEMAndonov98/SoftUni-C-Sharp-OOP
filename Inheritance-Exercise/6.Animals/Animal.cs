using System;
using System.Text;

namespace Animals
{
	public abstract class Animal
	{
		private string _name;
		private int _age;
		private string _gender;
        private bool isValid = true;

		public Animal(string name, int age, string gender)
		{
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
		}

        public string Name
		{ get { return this._name; }
			set
			{
                if (value == string.Empty)
                {
                    Console.WriteLine("Invalid input!");
                    this.isValid = false;
                }
                else
                {
					this._name = value;
                }
			}
		}
        public int Age
		{ get { return this._age; }
			set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid input!");
                    this.isValid = false;
                }
                else
                {
                    this._age = value;
                }
            }
		}
        public string Gender
        { get{ return this._gender; }
            set
            {
                if (value == string.Empty)
                {
                    Console.WriteLine("Invalid input!");
                    this.isValid = false;
                }
                else
                {
                    this._gender = value;
                }
            }
        }
        public bool IsValid { get { return this.isValid; } }

        public abstract string ProduceSound();
        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());
            return sb.ToString();
        }
    }
}

