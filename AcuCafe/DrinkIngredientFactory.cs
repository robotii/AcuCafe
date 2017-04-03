using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.ingredients;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class DrinkIngredientFactory
    {
        private static readonly Dictionary<string, Type> DrinkTypes = new Dictionary<string, Type>();

        public static IDrinkIngredient Create(string drinkName)
        {
            if (DrinkTypes.ContainsKey(drinkName))
            {
                return (IDrinkIngredient)Activator.CreateInstance(DrinkTypes[drinkName]);
            }

            return new DrinkIngredient("unknown", 0.0);
        }

        public static void RegisterDrinkIngredient(string name, Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IDrinkIngredient)))
            {
                DrinkTypes[name] = t;
            }
            else
            {
                throw new Exception("Cannot register drink that does not implement IDrink interface");
            }
        }
    }
}