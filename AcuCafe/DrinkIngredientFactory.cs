using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.ingredients;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class DrinkIngredientFactory : IDrinkIngredientFactory
    {
        private static readonly Dictionary<string, Type> DrinkIngredients = new Dictionary<string, Type>();

        public IDrinkIngredient Create(string ingredientName)
        {
            if (DrinkIngredients.ContainsKey(ingredientName))
            {
                return (IDrinkIngredient)Activator.CreateInstance(DrinkIngredients[ingredientName]);
            }

            return new DrinkIngredient(ingredientName, 0.0); // Should we throw here?
        }

        public void RegisterDrinkIngredient(string name, Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IDrinkIngredient)))
            {
                DrinkIngredients[name] = t;
            }
            else
            {
                throw new Exception("Cannot register drink ingredient that does not implement IDrinkIngredient interface");
            }
        }
    }
}