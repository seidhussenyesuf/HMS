using System;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class RegistrationForm : Form
    {
        private APIClient http = new APIClient();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }

                RegisterRequest vm = new RegisterRequest();
                vm.FullName = txtFullName.Text;
                vm.UserName = txtUsername.Text;
                vm.Password = txtPassword.Text;

                var response = await http.Register(vm);

                if (response != null && response.Success)
                {
                    MessageBox.Show("User registered successfully!");

                    MainDashboard dashboard = new MainDashboard("Receptionist", vm.UserName, vm.FullName);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "User registration failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}