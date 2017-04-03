using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class Tea : Drink
    {
        static Tea()
        {
            Validator = new TeaValidator();
        }

        public Tea() : base("Hot tea", 1.0)
        { }
    }
}