using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class AcuCafe
    {
        static AcuCafe()
        {
            DrinkFactory.RegisterDrink("Espresso", typeof(Espresso));
            DrinkFactory.RegisterDrink("HotTea", typeof(Tea));
            DrinkFactory.RegisterDrink("IceTea", typeof(IceTea));
        }

        public static IDrink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            IDrink drink = DrinkFactory.Create(type);

            if (hasMilk)
                drink.AddIngredient(new DrinkIngredient("milk", 0.5));

            if (hasSugar)
                drink.AddIngredient(new DrinkIngredient("sugar", 0.5));

            try
            {
                DrinkPreparer.Prepare(drink);
            }
            catch (Exception ex)
            {
                Console.WriteLine("We are unable to prepare your drink.");
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }

            return drink;
        }
    }
}