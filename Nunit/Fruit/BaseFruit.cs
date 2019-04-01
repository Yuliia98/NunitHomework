using System;

namespace Fruit
{
    public class BaseFruit
    {
        public double Weight { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }

        public BaseFruit(double weight, int amount, string name, string color, int price)
        {
            Weight = weight;
            Amount = amount;
            Name = name;
            Color = color;
            Price = price;
        }

        public double GetFruitsPriceByWeight() {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            else if (Weight < 0) {
                throw new ArgumentOutOfRangeException(nameof(Weight));
            }
            return Price * Weight;
        }

        public int GetFruitsPriceByAmount()
        {
            return Price * Amount;
        }

        public double GetFruitsTaxedPriceByAmount(double priceWithTax)
        {
            return priceWithTax * Amount;
        }

        public double GetTotalWeight() {
            return Amount * Weight;
        }

        public double GetPriceWithTax(double tax) {
            return Price + Price*tax;
        }
    }
}
