using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.drinks;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class DrinkFactory : IDrinkFactory
    {
        private readonly Dictionary<string, Type> _drinkTypes = new Dictionary<string, Type>();

        public IDrink Create(string drinkName)
        {
            if (_drinkTypes.ContainsKey(drinkName))
            {
                return (IDrink)Activator.CreateInstance(_drinkTypes[drinkName]);
            }

            return new Drink(); // TODO: Should we throw an exception here?
        }

        public void RegisterDrink(string name, Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IDrink)))
            {
                _drinkTypes[name] = t;
            }
            else
            {
                throw new Exception("Cannot register drink that does not implement IDrink interface");
            }
        }
    }
}