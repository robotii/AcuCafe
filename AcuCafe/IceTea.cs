namespace AcuCafe
{
    public class IceTea : Drink
    {

        static IceTea()
        {
            AllowedIngredients.Add("milk");
            AllowedIngredients.Add("sugar");
        }
        public IceTea() : base("Ice tea", 1.5)
        { }
    }
}