using System;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public static class DrinkPreparer
    {
        public static void Prepare(IDrink drink, IBaristaInformer informer)
        {
            string message = "We are preparing the following drink for you: " + drink.Description;
            informer.Inform(message);
        }
    }
}