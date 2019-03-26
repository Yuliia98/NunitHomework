namespace Fruit
{
    public class BasicStoreSet
    {
        public BaseFruit Apple()
        {
            return new BaseFruit(14, 100, "apple", "green", 12);            
        }

        public BaseFruit Banana()
        {
            return new BaseFruit(9, 56, "banana", "yellow", 34);            
        }

        public BaseFruit Orange()
        {
            return new BaseFruit(7, 12, "orange", "orange", 57);            
        }

        public BaseFruit Cherry()
        {
            return new BaseFruit(12, 230, "cherry", "red",14);
        }
    }
}
