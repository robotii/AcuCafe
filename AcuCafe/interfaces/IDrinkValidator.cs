using System.Collections.Generic;

namespace AcuCafe.interfaces 
{
    public interface IDrinkValidator
    {
        bool Validate(List<IDrinkIngredient> ingredients);
        string[] AllowedIngredients { get; }
    }

}