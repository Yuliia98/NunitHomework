using System.Collections.Generic;
using System.Linq;

namespace Fruit
{
    public class StoreActions
    {
        public int GetAllFruitsAmount(List<BaseFruit> fruitsList)
        {
            return fruitsList.Sum(e => e.Amount);
        }

        public double GetAllFruitsWeights(List<BaseFruit> fruitsList)
        {
            return fruitsList.Sum(e => e.Weight);
        }

        public List<string> GetFruitsNamesList(List<BaseFruit> fruitsList)
        {
            return fruitsList.Select(e => e.Name).Distinct().ToList();
        }

        public List<string> GetFruitsWeightNotGreater(List<BaseFruit> fruitsList, double boundaryWeight)
        {
            return fruitsList.Where(e => e.Weight <= boundaryWeight).Select(e => e.Name).ToList();
        }

        public double CalculateBasketPrice(List<BaseFruit> fruitsList)
        {
            double price = 0;

            foreach (var e in fruitsList)
            {
                price += e.GetFruitsPriceByWeight();
            }

            return price;
        }

        public double GetTotalFruitsWeight(List<BaseFruit> fruitsList)
        {
            double price = 0;

            foreach (var e in fruitsList)
            {
                price += e.GetTotalWeight();
            }

            return price;
        }

        public List<string> GetAllFruitColors(List<BaseFruit> fruitsList)
        {
            return fruitsList.Select(e => e.Color).Distinct().ToList();
        }
    }
}
