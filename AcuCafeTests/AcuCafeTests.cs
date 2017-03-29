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

        [TestMethod]
        public void TestEspressoPrice()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", false, false);
            Assert.AreEqual(1.8, d.Cost());
        }
    }
}
