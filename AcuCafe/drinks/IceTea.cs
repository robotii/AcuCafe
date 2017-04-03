using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class IceTea : Drink
    {

        public IceTea() : base("Ice tea", 1.5)
        {
            Validator = new IceTeaValidator(); 
        }
    }
}