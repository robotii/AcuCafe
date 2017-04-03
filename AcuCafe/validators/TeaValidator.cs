namespace AcuCafe.validators
{
    class TeaValidator : DrinkValidator
    {
        public TeaValidator()
        {
            AllowedIngredients = new[]
            {
                "milk",
                "sugar"
            };
        }
    }
}
