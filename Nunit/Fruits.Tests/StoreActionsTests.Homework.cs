using System;
using System.Collections.Generic;
using System.Linq;
using Fruit;
using NUnit.Framework;

namespace Fruits.Tests
{
    [TestFixture]
    class StoreActionsTests
    {
        private List<BaseFruit> _baseFruitList;
        private StoreActions _storeActions = new StoreActions();
        [SetUp]
        public void Initialize()
        {
            _baseFruitList = new List<BaseFruit>();
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

            _baseFruitList.Add(fruit1);
            _baseFruitList.Add(fruit2);
            _baseFruitList.Add(fruit3);
            _baseFruitList.Add(fruit4);
            _baseFruitList.Add(fruit5);
            _baseFruitList.Add(fruit6);
            _baseFruitList.Add(fruit7);
            _baseFruitList.Add(fruit8);
            _baseFruitList.Add(fruit9);
            _baseFruitList.Add(fruit10);
            _baseFruitList.Add(fruit11);
            _baseFruitList.Add(fruit12);
            _baseFruitList.Add(fruit13);
            _baseFruitList.Add(fruit14);
        }

        [Test]
        public void VerifyGetTotalFruitAmount()
        {
            var _actualAmount = _storeActions.GetAllFruitsAmount(_baseFruitList);
            Assert.That(_actualAmount, Is.EqualTo(181));
        }

        [Test]
        public void VerifyGetTotalFruitsAmountIfDecreasingAmount()
        {
            _baseFruitList.Where(x => x.Color.Equals("yellow")).ToList().ForEach(y => y.Amount -= 2);
            _baseFruitList.Where(x => x.Color.Equals("blue")).ToList().ForEach(y => y.Amount -= 3);
            _baseFruitList.Where(x => x.Color.Equals("green")).ToList().ForEach(y => y.Amount -= 5);
            var _actualAmount = _storeActions.GetAllFruitsAmount(_baseFruitList);
            Assert.That(_actualAmount, Is.EqualTo(138));
        }

        [Test]
        public void VerifyGetTotalWeightIfDecreasingAndIncreasingWeight()
        {
            _baseFruitList.Where(x => x.Color.Equals("red")).ToList().ForEach(y => y.Weight -= 2);
            _baseFruitList.Where(x => x.Color.Equals("blue")).ToList().ForEach(y => y.Weight += 3);
            _baseFruitList.Where(x => x.Color.Equals("yellow")).ToList().ForEach(y => y.Weight -= 2);
            _baseFruitList.Where(x => x.Color.Equals("green")).ToList().ForEach(y => y.Weight += 3);
            var _actualTotalWeight = _storeActions.GetAllFruitsWeights(_baseFruitList);
            Assert.That(_actualTotalWeight, Is.EqualTo(164));
        }

        [Test]
        public void VerifyGetFruitsNamesListOfGreenFruits()
        {
            var _expectedNames = new List<string>() { "Apple", "Avokado", "Durian", "Noina", "AppleGreen" };
            var _listOfGreenFruits = _baseFruitList.Where(x => x.Color.Equals("green")).ToList();
            var _actualNames = _storeActions.GetFruitsNamesList(_listOfGreenFruits);
            Assert.That(_actualNames, Is.EquivalentTo(_expectedNames));
        }

        [Test]
        public void VerifyCalculateBasketPrice()
        {
            var _listOfRedAndYellowfruits = _baseFruitList.Where(x => x.Color.Equals("red") || x.Color.Equals("yellow")).ToList();
            var _actualBasketPrice = _storeActions.CalculateBasketPrice(_listOfRedAndYellowfruits);
            Assert.That(_actualBasketPrice, Is.EqualTo(1120));
        }

    }
}
