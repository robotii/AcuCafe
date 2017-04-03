using System.Collections.Generic;
using System.Linq;
using AcuCafe.interfaces;
using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class Drink : IDrink
    {
        protected static IDrinkValidator Validator = new DrinkValidator();

        static Drink()
        {
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
                return Validator.AllowedIngredients.Aggregate(Name, (current, allowedIngredient)
                    => current + (_ingredients.Exists(item => item.Name == allowedIngredient) ? " with " : " without ") + allowedIngredient);
            }
        }

        public void AddIngredient(IDrinkIngredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public bool IsValid
        {
            get { return Validator.Validate(_ingredients); }
        }
    }
}