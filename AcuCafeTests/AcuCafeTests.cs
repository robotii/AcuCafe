using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcuCafeTests
{
    using AcuCafe;

    [TestClass]
    public class AcuCafeTests
    {
        [TestMethod]
        public void TestOrderDrink()
        {
            AcuCafe.OrderDrink("Espresso", false, false);
        }
    }
}
