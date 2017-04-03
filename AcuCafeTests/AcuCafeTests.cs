﻿using AcuCafe.ingredients;
using AcuCafe.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcuCafeTests
{
    using AcuCafe;

    [TestClass]
    public class AcuCafeTests
    {
        private IDrinkFactory _drinkFactory;
        private IDrinkIngredientFactory _drinkIngredientFactory;
        private IBaristaInformer _baristaInformer;

        /// <summary>
        /// Make sure we have a clean environment before each test
        /// </summary>
        [TestInitialize]
        public void SetupFactories()
        {
            _drinkFactory = new DrinkFactory();
            _drinkIngredientFactory = new DrinkIngredientFactory();
            _baristaInformer = new BaristaInformer();
        }

        [TestMethod]
        public void TestOrderDrink()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new string[] { });
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestPlainEspresso()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new string[] { });
            Assert.AreEqual(1.8, d.Cost());
            Assert.AreEqual("Espresso without milk without sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilk()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk" });
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso with milk without sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithSugar()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "sugar" });
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso without milk with sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilkAndSugar()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk", "sugar" });
            Assert.AreEqual(2.8, d.Cost());
            Assert.AreEqual("Espresso with milk with sugar", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestRuinedEspresso()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk", "sugar" });
            d.AddIngredient(new DrinkIngredient("coconut", 0.5));

            Assert.IsFalse(d.IsValid);
        }

        [TestMethod]
        public void TestRuinedIceTea()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer);
            IDrink d = cafe.OrderDrink("IceTea", new[] { "milk" });
            Assert.IsFalse(d.IsValid);
        }
    }
}
