using System.Collections.Generic;
using AcuCafe;
using AcuCafe.interfaces;
using AcuCafe.validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcuCafeTests
{
    [TestClass]
    public class TestEspressoValidator
    {

        [TestMethod]
        public void TestValidIngredientList()
        {
            EspressoValidator ev = new EspressoValidator();

            Assert.IsTrue(ev.Validate(new List<IDrinkIngredient> { new DrinkIngredientFactory().Create("milk") }));
            Assert.IsTrue(ev.Validate(new List<IDrinkIngredient> { new DrinkIngredientFactory().Create("sugar") }));
            Assert.IsTrue(ev.Validate(new List<IDrinkIngredient> { new DrinkIngredientFactory().Create("chocolate topping") }));
        }

        [TestMethod]
        public void TestInvalidIngredient()
        {
            EspressoValidator ev = new EspressoValidator();

            Assert.IsFalse(ev.Validate(new List<IDrinkIngredient> { new DrinkIngredientFactory().Create("coconut") }));
        }

    }
}