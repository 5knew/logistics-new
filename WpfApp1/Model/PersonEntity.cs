using WpfApp1.Model;
namespace WpfApp1.Model
{
    public abstract class PersonEntity
    {
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Images> Images { get; set; } = new List<Images>();
    }
}