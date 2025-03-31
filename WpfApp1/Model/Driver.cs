using System.ComponentModel.DataAnnotations;
namespace WpfApp1.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
        public int Experience { get; set; }
    }



}