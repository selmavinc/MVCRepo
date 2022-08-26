using System.ComponentModel.DataAnnotations;

namespace WebApiApplication.Model
{
    public class Order
    {
        [Key]
        public int OderId { get; set; }
        public string OrderItem { get; set; }
        public DateTime OrderDate { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string OredrStatus { get; set; }
    }
}
