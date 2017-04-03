using System;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public static class DrinkPreparer
    {
        public static void Prepare(IDrink drink, IBaristaInformer informer)
        {
            if (drink.IsValid)
            {
                string message = "We are preparing the following drink for you: " + drink.Description;
                informer.Inform(message);
            }
            else
            {
                throw new Exception("We could not prepare the following drink: " + drink.Description);
            }
        }
    }
}