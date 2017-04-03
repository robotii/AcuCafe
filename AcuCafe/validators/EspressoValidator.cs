namespace AcuCafe.validators
{
    class EspressoValidator : DrinkValidator
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
