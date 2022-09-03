namespace Template.Models
{
    public class TwelveGrain : Bread
    {

        public override void Bake()
        {
            //Here we put bake logic
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            //Ingerient mixing logic
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }
    }
}

