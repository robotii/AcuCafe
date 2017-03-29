using System;
using System.Collections.Generic;
using System.Linq;

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

    public static class DrinkPreparer
    {
        public static void Prepare(IDrink drink)
        {

            string message = "We are preparing the following drink for you: " + drink.Description;
            Console.WriteLine(message);
        }
    }


    public interface IDrink
    {
        string Name { get; }
        double Cost();

        void AddIngredient(IDrinkIngredient ingredient);
        string Description { get; }
    }

    public interface IDrinkIngredient
    {
        string Name { get; }
        double Cost();
    }

    public class DrinkIngredient : IDrinkIngredient
    {
        private readonly double _cost;
        public string Name { get; }

        public DrinkIngredient(string name, double cost)
        {
            Name = name;
            _cost = cost;
        }

        public double Cost()
        {
            return _cost;
        }
    }

    public class Drink : IDrink
    {
        static Drink()
        {
            AllowedIngredients = new List<string>();
        }

        public Drink()
        {
            _ingredients = new List<IDrinkIngredient>();
        }

        public Drink(string name, double cost) : this()
        {
            Name = name;
            _cost = cost;
        }

        protected static List<string> AllowedIngredients { get; }

        private readonly double _cost;
        private readonly List<IDrinkIngredient> _ingredients;

        public string Name { get; }

        public double Cost()
        {
            return _cost + _ingredients.Sum(i => i.Cost());
        }

        public string Description
        {
            get
            {
                return AllowedIngredients.Aggregate(Name, (current, allowedIngredient) 
                    => current + (_ingredients.Exists(item => item.Name == allowedIngredient) ? " with " : " without ") + allowedIngredient);
            }
        }

        public void AddIngredient(IDrinkIngredient ingredient)
        {
            _ingredients.Add(ingredient);

            // Check if we added something wrong
            if (!AllowedIngredients.Contains(ingredient.Name))
                throw new Exception("We just ruined the " + Name + " by adding " + ingredient.Name);
        }
    }

    public class Espresso : Drink
    {
        static Espresso()
        {
            AllowedIngredients.Add("milk");
            AllowedIngredients.Add("sugar");
        }

        public Espresso() : base("Espresso", 1.8)
        { }
    }

    public class Tea : Drink
    {
        static Tea()
        {
            AllowedIngredients.Add("milk");
            AllowedIngredients.Add("sugar");
        }

        public Tea() : base("Hot tea", 1.0)
        { }
    }

    public class IceTea : Drink
    {

        static IceTea()
        {
            AllowedIngredients.Add("milk");
            AllowedIngredients.Add("sugar");
        }
        public IceTea() : base("Ice tea", 1.5)
        { }
    }
}