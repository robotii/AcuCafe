using AcuCafe.interfaces;

namespace AcuCafe.ingredients
{
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
}