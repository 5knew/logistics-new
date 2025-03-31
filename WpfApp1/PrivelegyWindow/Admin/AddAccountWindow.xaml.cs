using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;
using WpfApp1.Service.Interface;

namespace WpfApp1.PrivelegyWindow.Admin
{
    public partial class AddAccountWindow : Window
    {
        private readonly IAuthService _authService;
        private readonly ICustomerService _customerService;
        private readonly IDriverService _driverService;

        private readonly List<Document> _documents = new();
        private readonly List<Images> _images = new();

        public AddAccountWindow(IAuthService authService, ICustomerService customerService, IDriverService driverService)
        {
            InitializeComponent();
            _authService = authService;
            _customerService = customerService;
            _driverService = driverService;
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            CustomerPanel.Visibility = selectedRole == "Customer" ? Visibility.Visible : Visibility.Collapsed;
            DriverPanel.Visibility = selectedRole == "Driver" ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            var role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "User";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните логин и пароль.");
                return;
            }

            if (role == "Customer")
            {
                var userAccount = new UserAccount
                {
                    Username = username,
                    Role = "Customer",
                    PasswordHash = "", // временно
                    Contacts = new List<Contact>
        {
            new Contact
            {
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneTextBox.Text
            }
        },
                    Addresses = new List<Address>
        {
            new Address { Street = AddressTextBox.Text }
        },
                    Documents = _documents,
                    Images = _images,
                    Customer = new Customer
                    {
                        CompanyName = CompanyNameTextBox.Text,
                        ContactPerson = ContactPersonTextBox.Text
                    }
                };

                userAccount.SetPassword(password);

                await _authService.CreateFullAccountAsync(userAccount);
                MessageBox.Show("Клиент и аккаунт успешно созданы.");
            }

            else if (role == "Driver")
            {
                var driver = new WpfApp1.Model.Driver
                {
                    FullName = DriverFullNameTextBox.Text,
                    PhoneNumber = DriverPhoneTextBox.Text,
                    LicenseNumber = LicenseNumberTextBox.Text,
                    Experience = int.TryParse(ExperienceTextBox.Text, out var exp) ? exp : 0
                };

                await _driverService.AddDriverAsync(driver);
                await _authService.RegisterAsync(username, password, "Driver");
                MessageBox.Show("Водитель и аккаунт успешно созданы.");
            }
            else if (role == "Admin")
            {
                await _authService.RegisterAsync(username, password, "Admin");
                MessageBox.Show("Аккаунт администратора создан.");
            }

            Close();
        }

        private void AddDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _documents.Add(new Document
                {
                    DocumentType = "Other",
                    FilePath = openFileDialog.FileName
                });

                MessageBox.Show("Документ добавлен: " + Path.GetFileName(openFileDialog.FileName));
            }
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.png)|*.jpg;*.png|All files (*.*)|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _images.Add(new Images
                {
                    FilePath = openFileDialog.FileName
                });

                MessageBox.Show("Изображение добавлено: " + Path.GetFileName(openFileDialog.FileName));
            }
        }
    }
}
