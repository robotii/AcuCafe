using AcuCafe.validators;

namespace AcuCafe
{
    public class Tea : Drink
    {
        static Tea()
        {
            Validator = new DrinkValidator();
            //AllowedIngredients.Add("milk");
            //AllowedIngredients.Add("sugar");
        }

        public Tea() : base("Hot tea", 1.0)
        { }
    }
}