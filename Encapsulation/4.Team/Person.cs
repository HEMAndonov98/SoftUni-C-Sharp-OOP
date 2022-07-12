using System;
namespace PersonsInfo
{
	public class Person
	{
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

		public Person(string firstName, string lastName, int age, decimal salary)
		{
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
		}

        public string FirstName { get { return this.firstName; } private set
            {
                if (ValidateName(value))
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                this.firstName = value;
            }
        }
        public string LastName { get { return this.lastName; } private set
            {
                if (ValidateName(value))
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastName = value;
            }
        }
        public int Age { get { return this.age; } private set
            {
                if (ValidateAge(value))
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }
        public decimal Salary { get { return this.salary; } private set
            {
                if (ValidateSalary(value))
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            percentage /= 100;

            if (this.Age < 30)
            {
                percentage /= 2;
            }
            percentage += 1;
            this.Salary *= percentage;
        }
        private bool ValidateName(string value)
        {
            return value.Length < 3;
        }
        private bool ValidateAge(int value)
        {
            return value <= 0;
        }
        private bool ValidateSalary(decimal value)
        {
            return value < 460;
        }
    }
}

