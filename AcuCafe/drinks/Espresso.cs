using AcuCafe.validators;

namespace AcuCafe.drinks
{
    public class Espresso : Drink
    {

        public Espresso() : base("Espresso", 1.8)
        {
            Validator = new EspressoValidator();
        }
    }
}