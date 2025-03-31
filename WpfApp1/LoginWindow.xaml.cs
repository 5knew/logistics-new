// LoginWindow.xaml.cs
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.PrivelegyWindow.Admin;
using WpfApp1.PrivelegyWindow.User;
using WpfApp1.Service.Interface;

namespace WpfApp1
{
    public partial class LoginWindow : Window
    {
        private readonly IAuthService _authService;

        public LoginWindow(IAuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            var user = await _authService.AuthenticateAsync(login, password);

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    var adminWindow = new AdminWindow(_authService, App.ServiceProvider.GetRequiredService<ICustomerService>());
                    adminWindow.Show();
                    this.Close();
                }
                else if (user.Role == "User")
                {
                    var userWindow = new UserWindow();
                    userWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неизвестная роль пользователя.");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}