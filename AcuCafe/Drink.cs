using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.interfaces;

namespace AcuCafe
{
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

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
    }
}