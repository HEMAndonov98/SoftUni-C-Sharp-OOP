namespace Prototype.Models
{
    public class SandwichMenu
    {
        private readonly IDictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            //In real application dependancy will be taken from constructor as argument to increase abstraction.
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }
            set
            {
                this.sandwiches[name] = value;
            }
        }


    }
}

