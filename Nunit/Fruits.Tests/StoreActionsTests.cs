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
        private readonly List<BaseFruit> _fruitsList = new List<BaseFruit>();
        private readonly StoreActions _storeActions = new StoreActions();

        [TestCase(34, 23)]
        [TestCase(45, 23)]
        [TestCase(23, 23)]
        [TestCase(7, 23)]
        [TestCase(28, 23)]

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

        [OneTimeSetUp]
        public void InitializeList()
        {
            _baseFruitsList.Add(new BasicStoreSet().Apple());
            _baseFruitsList.Add(new BasicStoreSet().Banana());
            _baseFruitsList.Add(new BasicStoreSet().Cherry());
            _baseFruitsList.Add(new BasicStoreSet().Orange());

            var fruit1 = new BaseFruit(12, 14, "Banan", "yellow", 20);
            var fruit2 = new BaseFruit(10, 16, "Apricot", "yellow", 25);
            var fruit3 = new BaseFruit(10, 16, "Apricot", "yellow", 25);
            var fruit4 = new BaseFruit(8, 10, "Apple", "green", 15);
            var fruit5 = new BaseFruit(10, 12, "Avokado", "green", 20);
            var fruit6 = new BaseFruit(8, 14, "Durian", "green", 15);
            var fruit7 = new BaseFruit(10, 18, "Noina", "green", 15);
            var fruit8 = new BaseFruit(8, 15, "AppleGreen", "green", 15);
            var fruit9 = new BaseFruit(12, 11, "Apple", "red", 15);
            var fruit10 = new BaseFruit(10, 11, "Cherry", "red", 20);
            var fruit11 = new BaseFruit(12, 11, "Sala", "blue", 15);
            var fruit12 = new BaseFruit(10, 11, "Carambola", "blue", 25);
            var fruit13 = new BaseFruit(12, 11, "Orange", "blue", 15);
            var fruit14 = new BaseFruit(15, 11, "Carrot", "blue", 35);

            _fruitsList.Add(fruit1);
            _fruitsList.Add(fruit2);
            _fruitsList.Add(fruit3);
            _fruitsList.Add(fruit4);
            _fruitsList.Add(fruit5);
            _fruitsList.Add(fruit6);
            _fruitsList.Add(fruit7);
            _fruitsList.Add(fruit8);
            _fruitsList.Add(fruit9);
            _fruitsList.Add(fruit10);
            _fruitsList.Add(fruit11);
            _fruitsList.Add(fruit12);
            _fruitsList.Add(fruit13);
            _fruitsList.Add(fruit14);
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

        [Test]
        public void VerifyGetTotalFruitAmount()
        {
            var _actualAmount = _storeActions.GetAllFruitsAmount(_fruitsList);
            Assert.That(_actualAmount, Is.EqualTo(181));
        }

        [Test]
        public void VerifyGetTotalFruitsAmountIfDecreasingAmount()
        {
            _fruitsList.Where(x => x.Color.Equals("yellow")).ToList().ForEach(y => y.Amount -= 2);
            _fruitsList.Where(x => x.Color.Equals("blue")).ToList().ForEach(y => y.Amount -= 3);
            _fruitsList.Where(x => x.Color.Equals("green")).ToList().ForEach(y => y.Amount -= 5);
            var _actualAmount = _storeActions.GetAllFruitsAmount(_fruitsList);
            Assert.That(_actualAmount, Is.EqualTo(138));
        }

        [Test]
        public void VerifyGetTotalWeightIfDecreasingAndIncreasingWeight()
        {
            _fruitsList.Where(x => x.Color.Equals("red")).ToList().ForEach(y => y.Weight -= 2);
            _fruitsList.Where(x => x.Color.Equals("blue")).ToList().ForEach(y => y.Weight += 3);
            _fruitsList.Where(x => x.Color.Equals("yellow")).ToList().ForEach(y => y.Weight -= 2);
            _fruitsList.Where(x => x.Color.Equals("green")).ToList().ForEach(y => y.Weight += 3);
            var _actualTotalWeight = _storeActions.GetAllFruitsWeights(_fruitsList);
            Assert.That(_actualTotalWeight, Is.EqualTo(164));
        }

        [Test]
        public void VerifyGetFruitsNamesListOfGreenFruits()
        {
            var _expectedNames = new List<string>() { "Apple", "Avokado", "Durian", "Noina", "AppleGreen" };
            var _listOfGreenFruits = _fruitsList.Where(x => x.Color.Equals("green")).ToList();
            var _actualNames = _storeActions.GetFruitsNamesList(_listOfGreenFruits);
            Assert.That(_actualNames, Is.EquivalentTo(_expectedNames));
        }

        [Test]
        public void VerifyCalculateBasketPrice()
        {
            var _listOfRedAndYellowfruits = _fruitsList.Where(x => x.Color.Equals("red") || x.Color.Equals("yellow")).ToList();
            var _actualBasketPrice = _storeActions.CalculateBasketPrice(_listOfRedAndYellowfruits);
            Assert.That(_actualBasketPrice, Is.EqualTo(1120));
        }

        [Test]
        public void ShouldGetFruitsColorsList()
        {
            var _expectedColors = new List<string>() { "green", "yellow", "red", "orange" };
            var _actualColors = _storeActions.GetAllFruitColors(_baseFruitsList);
            Assert.That(_actualColors, Is.EquivalentTo(_expectedColors));
        }




    }
}
