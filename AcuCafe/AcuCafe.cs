using System;
using System.Collections.Generic;
using AcuCafe.drinks;
using AcuCafe.ingredients;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class AcuCafe
    {
        private readonly IDrinkFactory _drinkFactory;
        private readonly IDrinkIngredientFactory _drinkIngredientFactory;

        public AcuCafe(IDrinkFactory df, IDrinkIngredientFactory dif)
        {
            _drinkFactory = df;
            _drinkIngredientFactory = dif;

            _drinkFactory.RegisterDrink("Espresso", typeof(Espresso));
            _drinkFactory.RegisterDrink("HotTea", typeof(Tea));
            _drinkFactory.RegisterDrink("IceTea", typeof(IceTea));

            _drinkIngredientFactory.RegisterDrinkIngredient("milk", typeof(MilkIngredient));
            _drinkIngredientFactory.RegisterDrinkIngredient("sugar", typeof(SugarIngredient));
        }

        [Obsolete("Please use OrderDrink(string, IEnumerable<string>) instead")]
        public static IDrink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            AcuCafe cafe = new AcuCafe(new DrinkFactory(), new DrinkIngredientFactory());
            List<string> ingredients = new List<string>();
            if(hasMilk)
                ingredients.Add("milk");
            if(hasSugar)
                ingredients.Add("sugar");

            return cafe.OrderDrink(type, ingredients);
        }

        public IDrink OrderDrink(string drinkType, IEnumerable<string> ingredients)
        {
            IDrink drink = _drinkFactory.Create(drinkType);

            foreach (string ingredient in ingredients)
            {
                drink.AddIngredient(_drinkIngredientFactory.Create(ingredient));
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