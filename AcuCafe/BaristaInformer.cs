using System;
using AcuCafe.interfaces;

namespace AcuCafe
{
    public class BaristaInformer : IBaristaInformer
    {
        public void Inform(string message)
        {
            Console.WriteLine(message);
        }
    }
}
