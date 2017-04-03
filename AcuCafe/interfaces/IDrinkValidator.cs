using System.Collections.Generic;

namespace AcuCafe.interfaces 
{
    interface IDrinkValidator
    {
        bool Validate(List<IDrinkIngredient> ingredients);
    }

}