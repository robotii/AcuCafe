using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public static class DrinkFactory
    {
        private static readonly Dictionary<string, Type> DrinkTypes = new Dictionary<string, Type>();

        public static IDrink Create(string drinkName)
        {
            if (DrinkTypes.ContainsKey(drinkName))
            {
                return (IDrink)Activator.CreateInstance(DrinkTypes[drinkName]);
            }

            return new Drink();
        }

        public static void RegisterDrink(string name, Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IDrink)))
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