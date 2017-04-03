namespace AcuCafe
{
    public class Espresso : Drink
    {
        static Espresso()
        {
            AllowedIngredients.Add("milk");
            AllowedIngredients.Add("sugar");
        }

        public Espresso() : base("Espresso", 1.8)
        { }
    }
}