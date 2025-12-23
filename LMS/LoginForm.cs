using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class LoginForm : Form
    {
        private APIClient http = new APIClient();
        private Color primaryColor = Color.FromArgb(41, 128, 185);
        private Color secondaryColor = Color.FromArgb(52, 152, 219);
        private Color accentColor = Color.FromArgb(231, 76, 60);
        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            ApplyModernStyles();
            LoadHotelImage();
        }

        private void ApplyModernStyles()
        {
            // Form styling
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Style buttons
            btnLogin.BackColor = accentColor;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            btnGoToRegister.BackColor = Color.Transparent;
            btnGoToRegister.FlatStyle = FlatStyle.Flat;
            btnGoToRegister.FlatAppearance.BorderSize = 1;
            btnGoToRegister.FlatAppearance.BorderColor = accentColor;
            btnGoToRegister.ForeColor = accentColor;
            btnGoToRegister.Font = new Font("Segoe UI", 10);
            btnGoToRegister.Cursor = Cursors.Hand;
            btnGoToRegister.MouseEnter += BtnGoToRegister_MouseEnter;
            btnGoToRegister.MouseLeave += BtnGoToRegister_MouseLeave;

            // Style textboxes
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.BackColor = Color.FromArgb(250, 250, 250);

            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BackColor = Color.FromArgb(250, 250, 250);

            // Style test buttons
            btnTestAdmin.FlatStyle = FlatStyle.Flat;
            btnTestAdmin.FlatAppearance.BorderSize = 1;
            btnTestAdmin.FlatAppearance.BorderColor = Color.White;
            btnTestAdmin.ForeColor = Color.White;
            btnTestAdmin.BackColor = Color.Transparent;
            btnTestAdmin.Font = new Font("Segoe UI", 9);
            btnTestAdmin.Cursor = Cursors.Hand;

            btnTestReception.FlatStyle = FlatStyle.Flat;
            btnTestReception.FlatAppearance.BorderSize = 1;
            btnTestReception.FlatAppearance.BorderColor = Color.White;
            btnTestReception.ForeColor = Color.White;
            btnTestReception.BackColor = Color.Transparent;
            btnTestReception.Font = new Font("Segoe UI", 9);
            btnTestReception.Cursor = Cursors.Hand;

            // Add password toggle button
            AddPasswordToggle();
        }

        private async void LoadHotelImage()
        {
            try
            {
                // Try to load from local file first
                string localImagePath = Path.Combine(Application.StartupPath, "Resources", "hotel.jpg");
                if (File.Exists(localImagePath))
                {
                    pictureBoxHotel.Image = Image.FromFile(localImagePath);
                }
                else
                {
                    // Fallback to online image or gradient
                    pictureBoxHotel.BackColor = Color.FromArgb(41, 128, 185);

                    // Create a simple gradient background for the picture box
                    using (var g = Graphics.FromHwnd(pictureBoxHotel.Handle))
                    {
                        using (var brush = new LinearGradientBrush(
                            pictureBoxHotel.ClientRectangle,
                            Color.FromArgb(41, 128, 185),
                            Color.FromArgb(52, 152, 219),
                            LinearGradientMode.ForwardDiagonal))
                        {
                            g.FillRectangle(brush, pictureBoxHotel.ClientRectangle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // If all else fails, set solid color
                pictureBoxHotel.BackColor = Color.FromArgb(41, 128, 185);
            }
        }

        private void AddPasswordToggle()
        {
            // Create a simple toggle button for password visibility
            Button btnToggle = new Button();
            btnToggle.Size = new Size(30, 30);
            btnToggle.Location = new Point(
                txtPassword.Right - 35,
                txtPassword.Top + 6
            );
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.BackColor = Color.FromArgb(240, 240, 240);
            btnToggle.Text = "👁️";
            btnToggle.Font = new Font("Segoe UI", 10);
            btnToggle.Cursor = Cursors.Hand;
            btnToggle.Click += (s, e) =>
            {
                passwordVisible = !passwordVisible;
                txtPassword.PasswordChar = passwordVisible ? '\0' : '•';
                btnToggle.Text = passwordVisible ? "🙈" : "👁️";
            };
            panelLogin.Controls.Add(btnToggle);
            btnToggle.BringToFront();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ShowModernMessage("Please enter username and password", "Input Required", MessageBoxIcon.Warning);
                    return;
                }

                // Show loading state
                btnLogin.Enabled = false;
                btnLogin.Text = "Authenticating...";

                var request = new LoginRequest
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text
                };

                var response = await http.Login(request);

                if (response.Success)
                {
                    ShowModernMessage("Login successful!", "Success", MessageBoxIcon.Information);

                    // Open Hotel Management Dashboard
                    string role = response.Role ?? "Receptionist";
                    string fullName = response.FullName ?? txtUsername.Text;

                    MainDashboard dashboard = new MainDashboard(role, txtUsername.Text, fullName);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    ShowModernMessage(response.Message ?? "Invalid credentials", "Login Error", MessageBoxIcon.Error);
                    ResetLoginButton();
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage($"Error: {ex.Message}\n\nMake sure the API is running on https://localhost:7018",
                    "Connection Error", MessageBoxIcon.Error);
                ResetLoginButton();
            }
        }

        private void ResetLoginButton()
        {
            btnLogin.Enabled = true;
            btnLogin.Text = "Login";
        }

        private void ShowModernMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        private void BtnGoToRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        private void BtnTestAdmin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "Admin@123";
            ShowModernMessage("Default admin credentials loaded.\nUsername: admin\nPassword: Admin@123",
                "Test Credentials", MessageBoxIcon.Information);
        }

        private void BtnTestReception_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "reception";
            txtPassword.Text = "Reception@123";
            ShowModernMessage("Default receptionist credentials loaded.\nUsername: reception\nPassword: Reception@123",
                "Test Credentials", MessageBoxIcon.Information);
        }

        // Hover effects
        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = accentColor;
        }

        private void BtnGoToRegister_MouseEnter(object sender, EventArgs e)
        {
            btnGoToRegister.BackColor = accentColor;
            btnGoToRegister.ForeColor = Color.White;
        }

        private void BtnGoToRegister_MouseLeave(object sender, EventArgs e)
        {
            btnGoToRegister.BackColor = Color.Transparent;
            btnGoToRegister.ForeColor = accentColor;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }

    // Custom gradient panel
    public class GradientPanel : Panel
    {
        public Color StartColor { get; set; } = Color.FromArgb(41, 128, 185);
        public Color EndColor { get; set; } = Color.FromArgb(52, 152, 219);
        public float Angle { get; set; } = 45f;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                StartColor,
                EndColor,
                Angle))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}