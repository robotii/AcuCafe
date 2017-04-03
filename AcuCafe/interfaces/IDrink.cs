namespace AcuCafe.interfaces
{
    public interface IDrink
    {
        string Name { get; }
        double Cost();
        void AddIngredient(IDrinkIngredient ingredient);
        string Description { get; }
        bool IsValid { get; }
    }
}