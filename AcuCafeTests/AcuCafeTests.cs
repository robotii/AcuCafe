using System;
using AcuCafe.interfaces;
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
            IDrink d = AcuCafe.OrderDrink("Espresso", false, false);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestPlainEspresso()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", false, false);
            Assert.AreEqual(1.8, d.Cost());
            Assert.AreEqual("Espresso without milk without sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilk()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", true, false);
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso with milk without sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithSugar()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", false, true);
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso without milk with sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilkAndSugar()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", true, true);
            Assert.AreEqual(2.8, d.Cost());
            Assert.AreEqual("Espresso with milk with sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestRuinedEspresso()
        {
            IDrink d = AcuCafe.OrderDrink("Espresso", true, true);
            try
            {
                d.AddIngredient(new DrinkIngredient("coconut", 0.5));
            }
            catch (Exception e)
            {
                Assert.AreEqual("We just ruined the Espresso by adding coconut", e.Message);
                Assert.IsFalse(d.IsValid);
                return;
            }

            Assert.Fail("No exception thrown when adding coconut to the Espresso!");
        }
    }
}
