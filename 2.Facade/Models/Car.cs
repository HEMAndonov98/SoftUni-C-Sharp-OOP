namespace Facade.Models
{
    using System.Text;

    public class Car
    {

        public Car()
        {

        }

        public Car(string make, string model, int year, int kilometers)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Kilometers = kilometers;
        }

        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int Kilometers { get; set; }

        public override string ToString()
        {
            var carSb = new StringBuilder();
            carSb.AppendLine($"Make: {this.Make}, Model {this.Model}");
            carSb.Append($"Year - {this.Year}, Kilometers passed: {this.Kilometers}");
            return carSb.ToString();
        }
    }
}

