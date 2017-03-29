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

        [TestMethod]
        public void TestEspressoWithMilk()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", true, false);
            Assert.AreEqual(2.3, d.Cost());
        }

        [TestMethod]
        public void TestEspressoWithSugar()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", false, true);
            Assert.AreEqual(2.3, d.Cost());
        }

        [TestMethod]
        public void TestEspressoWithMilkAndSugar()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", true, true);
            Assert.AreEqual(2.3, d.Cost());
        }
    }
}
