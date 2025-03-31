using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WpfApp1.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Capacity { get; set; }

        [ForeignKey("Driver")]
        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}