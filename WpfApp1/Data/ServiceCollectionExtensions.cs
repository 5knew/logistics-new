using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;
using WpfApp1.Service.Interface;
namespace WpfApp1.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server=localhost;database=logistics;user=root;password=root",
    ServerVersion.AutoDetect("server=localhost;database=logistics;user=root;password=root")));




            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepository<UserAccount>, Repository<UserAccount>>();
            services.AddScoped<IRepository<Driver>, Repository<Driver>>(); // ?? вот эта строка нужна
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();



            services.AddScoped<OrderService,OrderService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<OrderService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<AuthService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<DriverService>();

                  // ?? и эта




            // Регистрация окон
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginWindow>();

        }
    }
}