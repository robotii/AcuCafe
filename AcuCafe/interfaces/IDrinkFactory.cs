using System;

namespace AcuCafe.interfaces
{
    public interface IDrinkFactory
    {
        void RegisterDrink(string drinkType, Type type);
        IDrink Create(string drinkType);
    }
}