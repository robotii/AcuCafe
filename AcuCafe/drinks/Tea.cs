using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class Tea : Drink
    {
        public Tea() : base("Hot tea", 1.0)
        {
            Validator = new TeaValidator(); 
        }
    }
}