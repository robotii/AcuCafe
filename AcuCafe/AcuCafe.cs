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
        private readonly IBaristaInformer _informer;
        private readonly ILogger _logger;

        public AcuCafe(IDrinkFactory df, IDrinkIngredientFactory dif, IBaristaInformer bi, ILogger logger)
        {
            _drinkFactory = df;
            _drinkIngredientFactory = dif;
            _informer = bi;
            _logger = logger;

            _drinkFactory.RegisterDrink("Espresso", typeof(Espresso));
            _drinkFactory.RegisterDrink("HotTea", typeof(Tea));
            _drinkFactory.RegisterDrink("IceTea", typeof(IceTea));

            _drinkIngredientFactory.RegisterDrinkIngredient("milk", typeof(MilkIngredient));
            _drinkIngredientFactory.RegisterDrinkIngredient("sugar", typeof(SugarIngredient));
        }

        /// <summary>
        /// Takes a type of drink and whether it has milk or sugar and orders the drink
        /// This method is obsolete, but just in case existing code is using it, we will
        /// obsolete it for the time being and just leave the method here.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hasMilk"></param>
        /// <param name="hasSugar"></param>
        /// <returns></returns>
        [Obsolete("Please use OrderDrink(string, IEnumerable<string>) instead")]
        public static IDrink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            AcuCafe cafe = new AcuCafe(new DrinkFactory(), new DrinkIngredientFactory(), new BaristaInformer(), new Logger(@"c:\Error.txt"));
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
                DrinkPreparer.Prepare(drink, _informer);
            }
            catch (Exception ex)
            {
                _informer.Inform("We are unable to prepare your drink.");
                _logger.Log(ex.ToString());
            }

            return drink;
        }
    }
}