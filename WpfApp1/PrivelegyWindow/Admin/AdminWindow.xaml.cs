using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Model;
using WpfApp1.Service.Interface;

namespace WpfApp1.PrivelegyWindow.Admin
{
    public partial class AdminWindow : Window
    {
        private readonly IAuthService _authService;
        private readonly ICustomerService _customerService;

        public List<UserAccount> AdminUsers { get; set; } = new();
        public List<UserAccount> CustomerUsers { get; set; } = new();
        public List<UserAccount> DriverUsers { get; set; } = new();

        public UserAccount? SelectedUser { get; set; }

        public AdminWindow(IAuthService authService, ICustomerService customerService)
        {
            _authService = authService;
            _customerService = customerService;
            InitializeComponent();
            _ = InitializeAsync();
        }

        private void UserSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SelectedUser = e.AddedItems[0] as UserAccount;
                DataContext = null;
                DataContext = this;
            }
        }
        private async Task InitializeAsync()
        {
            await LoadUsers();
            //await LoadCustomers();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}");
            }

            e.Handled = true;
        }

        private async Task LoadUsers()
        {
            var users = (await _authService.GetAllWithProfilesAsync()).ToList();

            AdminUsers = users.Where(u => u.Role == "Admin").ToList();
            CustomerUsers = users.Where(u => u.Role == "Customer").ToList();
            DriverUsers = users.Where(u => u.Role == "Driver").ToList();

            DataContext = this; // обновляем биндинг
        }

        // Удали это, если список больше не используется:
        //private async Task LoadCustomers()
        //{
        //    var customers = await _customerService.GetAllCustomersAsync();
        //    CustomersListView.ItemsSource = customers; // <- вот здесь ошибка
        //}


        //private void AddUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var addAccountWindow = new AddAccountWindow(
        //        App.ServiceProvider.GetRequiredService<IAuthService>(),
        //        App.ServiceProvider.GetRequiredService<ICustomerService>(),
        //        App.ServiceProvider.GetRequiredService<IDriverService>()
        //    );
        //    addAccountWindow.ShowDialog();
        //    _ = LoadUsers();
        //}

        private async void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer
            {
                CompanyName = "New Company",
                ContactPerson = "New Contact"
            };
            await _customerService.AddCustomerAsync(newCustomer);
            //await LoadCustomers();
        }
    }
}
