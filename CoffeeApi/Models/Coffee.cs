namespace CoffeeApi.Models
{
    public class Coffee
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Coffee() { }

        public Coffee(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
