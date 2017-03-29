using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static IDrink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            IDrink drink = DrinkFactory.Create(type);

            if (hasMilk)
                drink.AddIngredient(new DrinkIngredient("milk", 0.5));

            if (hasSugar)
                drink.AddIngredient(new DrinkIngredient("sugar", 0.5));

            try
            {
                //drink.HasMilk = hasMilk;
                //drink.HasSugar = hasSugar;
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

        public static IDrink Create(string drinkName, params IDrinkIngredient[] ingredients)
        {
            if (DrinkTypes.ContainsKey(drinkName))
            {
                return (IDrink)Activator.CreateInstance(DrinkTypes[drinkName]);
            }

            // Fallback code in case the classes are not registered
            switch (drinkName)
            {
                case "Espresso":
                    return new Espresso();
                case "HotTea":
                    return new Tea();
                case "IceTea":
                    return new IceTea();
                default:
                    return new Drink();
            }
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

            string message = "We are preparing the following drink for you: " + drink.Name;
            /*if (drink.HasMilk)
                message += " with milk";
            else
                message += " without milk";

            if (drink.HasSugar)
                message += " with sugar";
            else
                message += " without sugar";
                */
            Console.WriteLine(message);
        }
    }


    public interface IDrink
    {
        string Name { get; }
        double Cost();

        void AddIngredient(IDrinkIngredient ingredient);
    }

    public interface IDrinkIngredient
    {
        string Name { get; }
        double Cost();
    }

    public class DrinkIngredient : IDrinkIngredient
    {
        private double _cost;
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

        public const double MilkCost = 0.5;
        public const double SugarCost = 0.5;

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }
        public string Name { get; }

        public double Cost()
        {
            return _cost + _ingredients.Sum(i => i.Cost());
        }

        public void AddIngredient(IDrinkIngredient ingredient)
        {
            _ingredients.Add(ingredient);

            // Check if we added something wrong
            if (!AllowedIngredients.Contains(ingredient.Name))
                throw new Exception("We just ruined the " + Name + "by adding " + ingredient.Name);
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
        public new string Description
        {
            get { return "Hot tea"; }
        }

        public new double Cost()
        {
            double cost = 1;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }

    public class IceTea : Drink
    {
        public new string Description
        {
            get { return "Ice tea"; }
        }

        public new double Cost()
        {
            double cost = 1.5;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }
}