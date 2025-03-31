using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WpfApp1.Model;
namespace WpfApp1.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public UserAccount UserAccount { get; set; } = null!;
    }
}
