using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WpfApp1.Model;
using System.Security.Cryptography;

public class UserAccount : PersonEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [ForeignKey("Driver")]
    public int? DriverId { get; set; }
    public Driver? Driver { get; set; }

    [ForeignKey("Admin")]
    public int? AdminId { get; set; }
    public Admin? Admin { get; set; }

    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Customer";

    public void SetPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        PasswordHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}
