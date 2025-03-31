using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;

using WpfApp1.Service;
namespace WpfApp1.Model
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }

        public string DocumentType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        public UserAccount UserAccount { get; set; } = null!;
    }
}