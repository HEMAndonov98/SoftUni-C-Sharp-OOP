namespace Template.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            //Here we put bake logic
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            //Ingerient mixing logic
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
    }
}

