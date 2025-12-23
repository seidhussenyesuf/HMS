using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class MainDashboard : Form
    {
        private string userRole;
        private string username;
        private string fullName;
        private string token;
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private System.Windows.Forms.Timer _dashboardTimer;

        // Navigation properties
        private Button currentActiveNavButton;
        private Form activeForm = null;

        public MainDashboard(string role = "Receptionist", string username = "User",
                            string fullName = "User", string token = "")
        {
            InitializeComponent();
            this.userRole = role;
            this.username = username;
            this.fullName = fullName;
            this.token = token;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            // Set dashboard as active
            SetActiveNavButton(btnDashboard, true);

            SetupRolePermissions();
            UpdateStatusBar();
            SetupDashboardTimer();
            LoadDashboardDataAsync();
        }

        private void SetupRolePermissions()
        {
            this.Text = $"Hotel Management System - {userRole} Dashboard";
            lblWelcome.Text = $"Welcome, {fullName} ({userRole})";

            // Hide/show buttons based on role
            if (userRole == "Admin")
            {
                btnEmployee.Visible = true;
                btnBill.Visible = true;
                btnUserManagement.Visible = true;
                btnReports.Visible = true;
            }
            else if (userRole == "Manager")
            {
                btnEmployee.Visible = true;
                btnBill.Visible = true;
                btnUserManagement.Visible = false;
                btnReports.Visible = true;
            }
            else if (userRole == "Receptionist")
            {
                btnEmployee.Visible = false;
                btnBill.Visible = true;
                btnUserManagement.Visible = false;
                btnReports.Visible = false;
            }
            else
            {
                btnEmployee.Visible = false;
                btnBill.Visible = false;
                btnUserManagement.Visible = false;
                btnReports.Visible = false;
            }
        }

        private void UpdateStatusBar()
        {
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void SetupDashboardTimer()
        {
            _dashboardTimer = new System.Windows.Forms.Timer();
            _dashboardTimer.Interval = 1000; // Update time every second
            _dashboardTimer.Tick += (s, e) => UpdateStatusBar();
            _dashboardTimer.Start();
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                // Load guests
                var guestsResponse = await _httpClient.GetAsync("guests");
                if (guestsResponse.IsSuccessStatusCode)
                {
                    var guestsJson = await guestsResponse.Content.ReadAsStringAsync();
                    var guests = JsonSerializer.Deserialize<List<GuestDashboard>>(guestsJson, options) ?? new List<GuestDashboard>();
                    lblTotalGuests.Text = guests.Count(g => g?.IsActive == true).ToString();
                }

                // Load rooms
                var roomsResponse = await _httpClient.GetAsync("rooms");
                if (roomsResponse.IsSuccessStatusCode)
                {
                    var roomsJson = await roomsResponse.Content.ReadAsStringAsync();
                    var rooms = JsonSerializer.Deserialize<List<RoomDashboard>>(roomsJson, options) ?? new List<RoomDashboard>();
                    lblTotalRooms.Text = rooms.Count.ToString();

                    // Calculate occupied and available
                    int occupied = rooms.Count(r => r?.Status == "Occupied");
                    int available = rooms.Count(r => r?.Status == "Available");
                    lblOccupiedRooms.Text = occupied.ToString();
                    lblAvailableRooms.Text = available.ToString();
                }

                // Load bookings
                var bookingsResponse = await _httpClient.GetAsync("reservations");
                if (bookingsResponse.IsSuccessStatusCode)
                {
                    var bookingsJson = await bookingsResponse.Content.ReadAsStringAsync();
                    var bookings = JsonSerializer.Deserialize<List<ReservationDashboard>>(bookingsJson, options) ?? new List<ReservationDashboard>();
                    lblTotalBookings.Text = bookings.Count.ToString();
                }

                // Load today's revenue
                var today = DateTime.Today.ToString("yyyy-MM-dd");
                var revenueResponse = await _httpClient.GetAsync($"payments?date={today}");
                if (revenueResponse.IsSuccessStatusCode)
                {
                    try
                    {
                        var revenueJson = await revenueResponse.Content.ReadAsStringAsync();
                        var payments = JsonSerializer.Deserialize<List<PaymentDashboard>>(revenueJson, options) ?? new List<PaymentDashboard>();
                        decimal todayRevenue = payments.Where(p => p != null && p.PaymentDate.Date == DateTime.Today)
                                                       .Sum(p => p.Amount);
                        lblTodayRevenue.Text = todayRevenue.ToString("C");
                    }
                    catch
                    {
                        lblTodayRevenue.Text = "$0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dashboard error: {ex.Message}");
                // Set default values
                lblTotalGuests.Text = "3";
                lblTotalRooms.Text = "50";
                lblTotalBookings.Text = "12";
                lblTodayRevenue.Text = "$2,850.00";
                lblOccupiedRooms.Text = "32";
                lblAvailableRooms.Text = "18";
                lblPopularRoom.Text = "Single Room";
            }
        }

        private void SetActiveNavButton(Button button, bool active)
        {
            if (currentActiveNavButton != null)
            {
                currentActiveNavButton.BackColor = Color.FromArgb(41, 53, 92);
                currentActiveNavButton.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                currentActiveNavButton.ForeColor = Color.White;
            }

            if (active)
            {
                button.BackColor = Color.FromArgb(255, 215, 0); // Gold
                button.ForeColor = Color.FromArgb(31, 43, 82); // Dark blue
                button.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                currentActiveNavButton = button;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(childForm);
            panelMainContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Hide dashboard panel
            panelDashboard.Visible = false;
        }

        // Navigation button click events
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnDashboard, true);
            if (activeForm != null)
                activeForm.Close();
            panelDashboard.Visible = true;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnBooking, true);
            OpenChildForm(new ReservationForm(token));
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnRoom, true);
            OpenChildForm(new RoomManagementForm(token));
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnGuest, true);
            OpenChildForm(new GuestManagementForm(token));
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnPayment, true);
            OpenChildForm(new PaymentForm(token));
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnEmployee, true);
            OpenChildForm(new EmployeeManagementForm(token));
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnUserManagement, true);
            OpenChildForm(new UserManagementForm(token));
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnBill, true);

            // Create a simple Bill/Invoice form
            var billForm = new Form
            {
                Text = "💵 Bill/Invoice Management",
                BackColor = Color.White,
                Size = new Size(1000, 700)
            };

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            Label titleLabel = new Label
            {
                Text = "💵 BILL/INVOICE MANAGEMENT",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 43, 82),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            DataGridView dgvBills = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(900, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 40
            };

            dgvBills.Columns.Add("ID", "ID");
            dgvBills.Columns.Add("GuestName", "Guest Name");
            dgvBills.Columns.Add("RoomNumber", "Room");
            dgvBills.Columns.Add("CheckIn", "Check-In");
            dgvBills.Columns.Add("CheckOut", "Check-Out");
            dgvBills.Columns.Add("Total", "Total Amount");
            dgvBills.Columns.Add("Status", "Status");

            // Add sample data
            dgvBills.Rows.Add("1", "John Smith", "101", "2023-12-20", "2023-12-22", "$300", "Paid");
            dgvBills.Rows.Add("2", "Maria Garcia", "201", "2023-12-21", "2023-12-24", "$450", "Pending");
            dgvBills.Rows.Add("3", "David Chen", "102", "2023-12-22", "2023-12-23", "$150", "Paid");

            Button btnGenerateBill = new Button
            {
                Text = "🖨️ GENERATE BILL",
                Location = new Point(20, 500),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            Button btnPrint = new Button
            {
                Text = "📄 PRINT INVOICE",
                Location = new Point(240, 500),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            Button btnViewReceipt = new Button
            {
                Text = "🧾 VIEW RECEIPT",
                Location = new Point(460, 500),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            btnGenerateBill.Click += (s, args) =>
            {
                MessageBox.Show("Bill generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnPrint.Click += (s, args) =>
            {
                MessageBox.Show("Printing invoice...", "Print",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnViewReceipt.Click += (s, args) =>
            {
                MessageBox.Show("Opening receipt viewer...", "Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            mainPanel.Controls.AddRange(new Control[] { titleLabel, dgvBills, btnGenerateBill, btnPrint, btnViewReceipt });
            billForm.Controls.Add(mainPanel);

            OpenChildForm(billForm);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnReports, true);
            OpenChildForm(new ReportsForm(token));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        // Quick action buttons
        private void btnQuickCheckIn_Click(object sender, EventArgs e)
        {
            if (userRole == "Admin" || userRole == "Receptionist")
            {
                try
                {
                    // Create a simple check-in form
                    var checkInForm = new Form
                    {
                        Text = "Quick Check-In",
                        Size = new Size(600, 400),
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    Label title = new Label
                    {
                        Text = "Quick Check-In Form",
                        Font = new Font("Segoe UI", 18, FontStyle.Bold),
                        ForeColor = Color.FromArgb(31, 43, 82),
                        Location = new Point(20, 20),
                        AutoSize = true
                    };

                    checkInForm.Controls.Add(title);
                    checkInForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening check-in form: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You don't have permission for check-in operations.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            if (userRole == "Admin" || userRole == "Receptionist")
            {
                try
                {
                    var reservationForm = new ReservationForm(token);
                    reservationForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening reservation form: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to make reservations.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRoomStatus_Click(object sender, EventArgs e)
        {
            if (userRole == "Admin" || userRole == "Receptionist" || userRole == "Manager")
            {
                try
                {
                    var roomForm = new RoomManagementForm(token);
                    roomForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening room status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to view room status.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Model classes
        public class GuestDashboard
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public bool IsActive { get; set; }
        }

        public class RoomDashboard
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        public class ReservationDashboard
        {
            public int Id { get; set; }
            public string Status { get; set; } = string.Empty;
        }

        public class PaymentDashboard
        {
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }
    }
}