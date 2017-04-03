using System;
using System.Collections.Generic;
using AcuCafe.drinks;
using AcuCafe.ingredients;
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

            DrinkIngredientFactory.RegisterDrinkIngredient("milk", typeof(MilkIngredient));
            DrinkIngredientFactory.RegisterDrinkIngredient("sugar", typeof(SugarIngredient));
        }

        [Obsolete("Please use OrderDrink(string, IEnumerable<string>) instead")]
        public static IDrink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            IDrink drink = DrinkFactory.Create(type);

            if (hasMilk)
                drink.AddIngredient(DrinkIngredientFactory.Create("milk"));

            if (hasSugar)
                drink.AddIngredient(DrinkIngredientFactory.Create("sugar"));

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

        public static IDrink OrderDrink(string drinkType, IEnumerable<string> ingredients)
        {
            IDrink drink = DrinkFactory.Create(drinkType);

            foreach (string ingredient in ingredients)
            {
                drink.AddIngredient(DrinkIngredientFactory.Create(ingredient));
            }

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