using Fruit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruits.Tests
{
    [TestFixture]
    class StoreActionsTests
    {
        private readonly List<BaseFruit> _baseFruitsList = new List<BaseFruit>();
        private readonly StoreActions _storeActions = new StoreActions();

        [TestCase(34,23)]
        [TestCase(45,23)]
        [TestCase(23,23)]
        [TestCase(7,23)]
        [TestCase(28,23)]
        public void ShouldGetAllFruitsAmount(int amountFruit1, int amountFruit2)
        {
            var fruit1 = new BaseFruit(23.4, amountFruit1, "Plola", "orange", 34);
            var fruit2 = new BaseFruit(23.4, amountFruit2, "Plola", "orange", 34);
            var mfruits = new List<BaseFruit>();
            mfruits.Add(fruit1);
            mfruits.Add(fruit2);
            var actualAmount = _storeActions.GetAllFruitsAmount(mfruits);
            Assert.That(actualAmount, Is.EqualTo(mfruits.Sum(x => x.Amount)));
        }

        [TestCase(3.4, 2.3)]
        [TestCase(4.5, 2.3)]
        [TestCase(2.3, 2.3)]
        [TestCase(7, 2.3)]
        [TestCase(2.8, 2.3)]

        public void ShouldGetAllFruitsWeights(double weightFruit1, double weightFruit2)
        {
            var fruit1 = new BaseFruit(weightFruit1, 20, "Plola", "orange", 34);
            var fruit2 = new BaseFruit(weightFruit2, 30, "Plola", "orange", 34);
            var mfruits = new List<BaseFruit>();
            mfruits.Add(fruit1);
            mfruits.Add(fruit2);
            var actualAmount = _storeActions.GetAllFruitsWeights(mfruits);
            Assert.That(actualAmount, Is.EqualTo(mfruits.Sum(x => x.Weight)));
        }

        [SetUp]
        public void InitializeList()
        {
            _baseFruitsList.Add(new BasicStoreSet().Apple());
            _baseFruitsList.Add(new BasicStoreSet().Banana());
            _baseFruitsList.Add(new BasicStoreSet().Cherry());
            _baseFruitsList.Add(new BasicStoreSet().Orange());
        }

        [Test]
        public void ShouldCalculateBasketPrice()
        {
            var actualBasketPrice = _storeActions.CalculateBasketPrice(_baseFruitsList);
            Assert.That(actualBasketPrice, Is.EqualTo(1041));
        }

        [Test]
        public void ShouldGetTotalFruitsWeight()
        {
            var actualFruitsWeight = _storeActions.GetTotalFruitsWeight(_baseFruitsList);
            Assert.That(actualFruitsWeight, Is.EqualTo(4748));
        }

        [Test]
        public void ShouldGetFruitsNamesList()
        {
            var expectedFruitNameList = new List<string>() { "apple","banana","cherry","orange"};
            var actualFruitNameList = _storeActions.GetFruitsNamesList(_baseFruitsList);
            Assert.That(actualFruitNameList, Is.EquivalentTo(expectedFruitNameList));
        }

        [Test]
        public void ShouldGetFruitsWeightNotGreater()
        {
            var expectedFruitsWeightNotGreater = new List<string>() { "banana", "orange"};
            var actualList = _storeActions.GetFruitsWeightNotGreater(_baseFruitsList, 10);
            Assert.That(actualList, Is.EquivalentTo(expectedFruitsWeightNotGreater));
        }

         



    }
}
