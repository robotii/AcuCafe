using AcuCafe.validators;

namespace AcuCafe
{
    public class Espresso : Drink
    {
        static Espresso()
        {
            Validator = new EspressoValidator();
        }

        public Espresso() : base("Espresso", 1.8)
        {
        }
    }
}