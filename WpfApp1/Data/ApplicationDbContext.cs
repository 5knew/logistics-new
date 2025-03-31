using System.Text;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> CustomerContacts { get; set; }
        public DbSet<Document> CustomerDocuments { get; set; }
        public DbSet<Address> CustomerAddresses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Images> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>()
                .HasMany(u => u.Contacts)
                .WithOne(c => c.UserAccount)
                .HasForeignKey(c => c.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAccount>()
                .HasMany(u => u.Documents)
                .WithOne(d => d.UserAccount)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAccount>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.UserAccount)
                .HasForeignKey(a => a.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAccount>()
                .HasMany(u => u.Images)
                .WithOne(i => i.UserAccount)
                .HasForeignKey(i => i.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }





        public async Task InitializeDatabaseAsync()
        {
            if (Database.EnsureCreated())
            {
                Console.WriteLine("Database has been created.");
            }

            if (!Customers.Any() && !UserAccounts.Any())
            {
                var adminUser = new UserAccount
                {
                    Username = "admin",
                    PasswordHash = HashPassword("admin123"),
                    Role = "Admin"
                };

                var regularUser = new UserAccount
                {
                    Username = "user",
                    PasswordHash = HashPassword("user123"),
                    Role = "User"
                };

                UserAccounts.Add(adminUser);
                UserAccounts.Add(regularUser);

                var customer1 = new Customer
                {
                    CompanyName = "Company One",
                    ContactPerson = "John Doe",
                };

                var customer2 = new Customer
                {
                    CompanyName = "Company Two",
                    ContactPerson = "Jane Smith",
                };

                Customers.Add(customer1);
                Customers.Add(customer2);

                await SaveChangesAsync();

                Images.AddRange(
                    new Images { FilePath = "images/john_doe.jpg", UserAccountId = adminUser.Id },
                    new Images { FilePath = "images/jane_smith.jpg", UserAccountId = regularUser.Id });

                CustomerAddresses.AddRange(
                    new Address { UserAccountId = adminUser.Id, Street = "123 Main St", City = "New York", PostalCode = "10001", Country = "USA" },
                    new Address { UserAccountId = regularUser.Id, Street = "456 Oak St", City = "Los Angeles", PostalCode = "90001", Country = "USA" });

                CustomerContacts.AddRange(
                    new Contact { UserAccountId = adminUser.Id, PhoneNumber = "123-456-7890", Email = "john.doe@example.com" },
                    new Contact { UserAccountId = regularUser.Id, PhoneNumber = "987-654-3210", Email = "jane.smith@example.com" });

                CustomerDocuments.AddRange(
                    new Document { UserAccountId = adminUser.Id, DocumentType = "Passport", FilePath = "documents/john_passport.pdf" },
                    new Document { UserAccountId = regularUser.Id, DocumentType = "ID Card", FilePath = "documents/jane_idcard.pdf" });


                await SaveChangesAsync();

                Console.WriteLine("Test data has been added to the database.");
            }
            else
            {
                Console.WriteLine("Database already contains data.");
            }

            await Database.MigrateAsync();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}