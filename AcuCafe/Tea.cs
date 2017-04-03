namespace AcuCafe
{
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
}