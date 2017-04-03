using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class IceTea : Drink
    {

        static IceTea()
        {
            Validator = new IceTeaValidator();
        }
        public IceTea() : base("Ice tea", 1.5)
        { }
    }
}