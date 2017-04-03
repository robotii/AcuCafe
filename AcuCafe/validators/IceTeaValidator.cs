namespace AcuCafe.validators
{
    class IceTeaValidator : DrinkValidator
    {
        public IceTeaValidator()
        {
            AllowedIngredients = new[]
            {
                "sugar"
            };
        }
    }
}
