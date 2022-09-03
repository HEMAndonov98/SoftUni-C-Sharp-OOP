namespace Prototype.Models
{
    public class Sandwich : SandwichPrototype
    {
        //Public fields just for the exercise in real application fields will be private and will be set through some kind of validation
        public string? bread;
        public string? meat;
        public string? cheese;
        public string? veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = this.GetIngridients();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientList}");

            return (SandwichPrototype)this.MemberwiseClone();
        }

        private string GetIngridients()
            => $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
    }
}

