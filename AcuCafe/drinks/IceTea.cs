using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class IceTea : Drink
    {

        static IceTea()
        {
            Validator = new DrinkValidator();
            //AllowedIngredients.Add("milk");
            //AllowedIngredients.Add("sugar");
        }
        public IceTea() : base("Ice tea", 1.5)
        { }
    }
}