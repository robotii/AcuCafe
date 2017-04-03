using System;

namespace AcuCafe.interfaces
{
    public interface IDrinkIngredientFactory
    {
        void RegisterDrinkIngredient(string name, Type type);
        IDrinkIngredient Create(string ingredientName);
    }
}