namespace AcuCafe.interfaces
{
    public interface IDrinkIngredient
    {
        string Name { get; }
        double Cost();
    }
}