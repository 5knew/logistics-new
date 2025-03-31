using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WpfApp1.Model
{
    public class Images
    {
        [Key]
        public int Id { get; set; }
        public string FilePath { get; set; } = null!;

        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; } = null!;
    }
}