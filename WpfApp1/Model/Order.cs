using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WpfApp1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Distance { get; set; }
        public decimal CargoWeight { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;
        public DateTime OrderDate { get; set; }
    }

}
