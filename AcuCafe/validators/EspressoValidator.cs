namespace AcuCafe.validators
{
    public class EspressoValidator : DrinkValidator
    {
        public EspressoValidator()
        {
            AllowedIngredients = new []
            {
                "milk",
                "sugar",
                "chocolate topping"
            };
        }
    }
}
