using System.Collections.Generic;
using System.Linq;
using AcuCafe.interfaces;

namespace AcuCafe.validators
{
    class DrinkValidator : IDrinkValidator
    {
        public DrinkValidator()
        {
            AllowedIngredients = new string[] {};
        }

        public bool Validate(List<IDrinkIngredient> ingredients)
        {
            foreach (IDrinkIngredient drinkIngredient in ingredients)
            {
                if (!AllowedIngredients.Contains(drinkIngredient.Name))
                    return false;
            }

            return true;
        }

        public string[] AllowedIngredients { get; set; }
    }
}
