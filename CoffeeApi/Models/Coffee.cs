using System.ComponentModel.DataAnnotations;

namespace CoffeeApi.Models
{
    public class Coffee
    {
        [Key] // 이 속성이 DB의 기본키(ID)가 된다.
        public int Id { get; set; }
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
