namespace Template.Models
{
    public class SourDough : Bread
    {
        public override void Bake()
        {
            //Here we put bake logic
            Console.WriteLine("Baking the SourDough Bread. (45 minutes)");
        }

        public override void MixIngredients()
        {
            //Ingerient mixing logic
            Console.WriteLine("Gathering Ingredients for SourDough Bread.");
        }
    }
}

