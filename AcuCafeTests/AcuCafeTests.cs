using AcuCafe.ingredients;
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
        private ILogger _logger;

        /// <summary>
        /// Make sure we have a clean environment before each test
        /// </summary>
        [TestInitialize]
        public void SetupFactories()
        {
            _drinkFactory = new DrinkFactory();
            _drinkIngredientFactory = new DrinkIngredientFactory();
            _baristaInformer = new TestBaristaInformer();
            _logger = new TestLogger();
        }

        [TestMethod]
        public void TestOrderDrink()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new string[] { });
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestPlainEspresso()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new string[] { });
            Assert.AreEqual(1.8, d.Cost());
            Assert.AreEqual("Espresso without milk without sugar without chocolate topping", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilk()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk" });
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso with milk without sugar without chocolate topping", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithSugar()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "sugar" });
            Assert.AreEqual(2.3, d.Cost());
            Assert.AreEqual("Espresso without milk with sugar without chocolate topping", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestEspressoWithMilkAndSugar()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk", "sugar" });
            Assert.AreEqual(2.8, d.Cost());
            Assert.AreEqual("Espresso with milk with sugar without chocolate topping", d.Description);
            Assert.IsTrue(d.IsValid);
        }

        [TestMethod]
        public void TestRuinedEspresso()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "milk", "sugar" });
            d.AddIngredient(new DrinkIngredient("coconut", 0.5));

            Assert.IsFalse(d.IsValid);
        }

        [TestMethod]
        public void TestRuinedIceTea()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("IceTea", new[] { "milk" });
            Assert.IsFalse(d.IsValid);
        }

        [TestMethod]
        public void TestChocolateToppingOnEspresso()
        {
            AcuCafe cafe = new AcuCafe(_drinkFactory, _drinkIngredientFactory, _baristaInformer, _logger);
            IDrink d = cafe.OrderDrink("Espresso", new[] { "chocolate topping"});
            Assert.IsTrue(d.IsValid);
            Assert.AreEqual(1.5, d.Cost());

            // Now try with milk
            d = cafe.OrderDrink("Espresso", new[] { "milk", "chocolate topping" });
            Assert.IsTrue(d.IsValid);
            Assert.AreEqual(1.8, d.Cost());

            // Now try with sugar
            d = cafe.OrderDrink("Espresso", new[] { "sugar", "chocolate topping" });
            Assert.IsTrue(d.IsValid);
            Assert.AreEqual(1.8, d.Cost());

            // Now try with milk and sugar
            d = cafe.OrderDrink("Espresso", new[] { "milk", "sugar", "chocolate topping" });
            Assert.IsTrue(d.IsValid);
            Assert.AreEqual(2.3, d.Cost());
        }
    }
}
