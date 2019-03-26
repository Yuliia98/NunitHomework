using NUnit.Framework;
using Fruit;
using System;

namespace Fruits.Tests
{
    [TestFixture ,Category("base store")]
    public class BaseFruitTests
    {
        [Test]
        public void ShouldGetFruitsPriceByWeight() {

            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", 10);

            var actualPriceByWeight = fruit.GetFruitsPriceByWeight();

            Assert.That(actualPriceByWeight, Is.EqualTo(25));
            Assert.That(actualPriceByWeight, Is.LessThanOrEqualTo(25));

            Assert.AreEqual(actualPriceByWeight, 25);            
        }

        [Test]
        public void ShouldGetFruitsPriceByWeight_ThrowsWeightException()
        {

            var fruit = new BaseFruit(-2.5, 12, "someFruit", "black", 10);

            Assert.Throws<ArgumentOutOfRangeException>(() => fruit.GetFruitsPriceByWeight());
        }

        [Test]
        public void ShouldGetFruitsPriceByWeight_ThrowsPriceException()
        {

            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", -10);

            Assert.Throws<ArgumentOutOfRangeException>(() => fruit.GetFruitsPriceByWeight());
        }

        [Test]
        public void ShouldGetFruitsPriceByAmount()
        {
            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", 10);

            var actualPriceByWeight = fruit.GetFruitsPriceByAmount();

            Assert.AreEqual(actualPriceByWeight, 120);
        }

        [Test]
        public void ShouldGetTotalWeight() {

            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", 10);

            var actualPriceByWeight = fruit.GetTotalWeight();

            Assert.AreEqual(actualPriceByWeight, 30);
        }       

        [Test]
        public void ShouldGetFruitsTaxedPriceByAmount()
        {
            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", 10);

            var actualTaxedPrice = fruit.GetFruitsTaxedPriceByAmount(3.5);
            Assert.AreEqual(42, actualTaxedPrice);
            Assert.That(actualTaxedPrice, Is.EqualTo(42));

        }

        [Test]
        public void ShouldGetGetPriceWithTax()
        {
            var fruit = new BaseFruit(2.5, 12, "someFruit", "black", 10);

            var actualTaxedPrice = fruit.GetPriceWithTax(2.5);
            Assert.AreEqual(35, actualTaxedPrice);
            Assert.That(actualTaxedPrice, Is.EqualTo(35));

        }
    }
}
