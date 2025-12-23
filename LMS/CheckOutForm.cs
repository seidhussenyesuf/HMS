using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class CheckOutForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<CheckOutReservation> _reservations = new BindingList<CheckOutReservation>();
        private string _token;
        private decimal _totalAmount = 0;

        public CheckOutForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();

            // Wire up button events
            btnLoadReservations.Click += BtnLoadReservations_Click;
            btnCalculate.Click += BtnCalculate_Click;
            btnProcessCheckOut.Click += BtnProcessCheckOut_Click;
            btnPrintReceipt.Click += BtnPrintReceipt_Click;

            SetupForm();
        }

        private void SetupHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            }
        }

        private void SetupForm()
        {
            SetupDataGridView();
            LoadReservationsAsync();
        }

        private void SetupDataGridView()
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.Columns.Clear();

            // Add columns
            DataGridViewTextBoxColumn colResId = new DataGridViewTextBoxColumn();
            colResId.Name = "colResID";
            colResId.HeaderText = "Res ID";
            colResId.DataPropertyName = "Id";
            colResId.Width = 70;
            dgvReservations.Columns.Add(colResId);

            DataGridViewTextBoxColumn colGuestName = new DataGridViewTextBoxColumn();
            colGuestName.Name = "colGuestName";
            colGuestName.HeaderText = "Guest Name";
            colGuestName.DataPropertyName = "GuestName";
            colGuestName.Width = 150;
            dgvReservations.Columns.Add(colGuestName);

            DataGridViewTextBoxColumn colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.HeaderText = "Room No";
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomNumber.Width = 80;
            dgvReservations.Columns.Add(colRoomNumber);

            DataGridViewTextBoxColumn colCheckIn = new DataGridViewTextBoxColumn();
            colCheckIn.Name = "colCheckIn";
            colCheckIn.HeaderText = "Check-In";
            colCheckIn.DataPropertyName = "CheckInDate";
            colCheckIn.Width = 100;
            colCheckIn.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvReservations.Columns.Add(colCheckIn);

            DataGridViewTextBoxColumn colCheckOut = new DataGridViewTextBoxColumn();
            colCheckOut.Name = "colCheckOut";
            colCheckOut.HeaderText = "Check-Out";
            colCheckOut.DataPropertyName = "CheckOutDate";
            colCheckOut.Width = 100;
            colCheckOut.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvReservations.Columns.Add(colCheckOut);

            DataGridViewTextBoxColumn colNights = new DataGridViewTextBoxColumn();
            colNights.Name = "colNights";
            colNights.HeaderText = "Nights";
            colNights.DataPropertyName = "NumberOfNights";
            colNights.Width = 70;
            dgvReservations.Columns.Add(colNights);

            DataGridViewTextBoxColumn colTotalAmount = new DataGridViewTextBoxColumn();
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.HeaderText = "Total Amount";
            colTotalAmount.DataPropertyName = "TotalAmount";
            colTotalAmount.Width = 120;
            colTotalAmount.DefaultCellStyle.Format = "C2";
            dgvReservations.Columns.Add(colTotalAmount);
        }

        private async void LoadReservationsAsync()
        {
            try
            {
                ShowStatus("Loading checked-in reservations...");
                var response = await _httpClient.GetAsync("reservations");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var reservationList = JsonSerializer.Deserialize<List<ApiReservation>>(json, options) ?? new List<ApiReservation>();

                    // Filter checked-in reservations
                    var checkedInReservations = new List<CheckOutReservation>();
                    foreach (var apiRes in reservationList)
                    {
                        if (apiRes.Status == "Checked-In")
                        {
                            checkedInReservations.Add(new CheckOutReservation
                            {
                                Id = apiRes.Id,
                                GuestName = await GetGuestNameById(apiRes.GuestId),
                                RoomNumber = await GetRoomNumberById(apiRes.RoomId),
                                CheckInDate = apiRes.CheckInDate,
                                CheckOutDate = apiRes.CheckOutDate,
                                NumberOfNights = (int)(apiRes.CheckOutDate - apiRes.CheckInDate).TotalDays,
                                TotalAmount = apiRes.TotalAmount,
                                Status = apiRes.Status
                            });
                        }
                    }

                    _reservations = new BindingList<CheckOutReservation>(checkedInReservations);

                    dgvReservations.DataSource = null;
                    dgvReservations.DataSource = _reservations;
                    dgvReservations.ClearSelection();

                    ShowStatus($"Loaded {_reservations.Count} checked-in reservations");
                }
                else
                {
                    UseDummyReservations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyReservations();
            }
        }

        private async Task<string> GetGuestNameById(int guestId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"guests/{guestId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var guest = JsonSerializer.Deserialize<ApiGuest>(json, options);
                    return $"{guest?.FirstName} {guest?.LastName}" ?? "Unknown Guest";
                }
            }
            catch { }
            return "Unknown Guest";
        }

        private async Task<string> GetRoomNumberById(int roomId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"rooms/{roomId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var room = JsonSerializer.Deserialize<ApiRoom>(json, options);
                    return room?.RoomNumber ?? "N/A";
                }
            }
            catch { }
            return "N/A";
        }

        private void UseDummyReservations()
        {
            _reservations = new BindingList<CheckOutReservation>
            {
                new CheckOutReservation {
                    Id = 1,
                    GuestName = "John Smith",
                    RoomNumber = "101",
                    CheckInDate = DateTime.Today.AddDays(-3),
                    CheckOutDate = DateTime.Today,
                    NumberOfNights = 3,
                    TotalAmount = 240.00m,
                    Status = "Checked-In"
                },
                new CheckOutReservation {
                    Id = 2,
                    GuestName = "Maria Garcia",
                    RoomNumber = "201",
                    CheckInDate = DateTime.Today.AddDays(-2),
                    CheckOutDate = DateTime.Today,
                    NumberOfNights = 2,
                    TotalAmount = 240.00m,
                    Status = "Checked-In"
                },
                new CheckOutReservation {
                    Id = 3,
                    GuestName = "David Chen",
                    RoomNumber = "301",
                    CheckInDate = DateTime.Today.AddDays(-1),
                    CheckOutDate = DateTime.Today.AddDays(2),
                    NumberOfNights = 1,
                    TotalAmount = 250.00m,
                    Status = "Checked-In"
                }
            };

            dgvReservations.DataSource = null;
            dgvReservations.DataSource = _reservations;
            dgvReservations.ClearSelection();

            ShowStatus("Using sample reservation data");
        }

        private void BtnLoadReservations_Click(object sender, EventArgs e)
        {
            LoadReservationsAsync();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to calculate", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvReservations.SelectedRows[0];
            var reservation = selectedRow.DataBoundItem as CheckOutReservation;

            if (reservation != null)
            {
                // Calculate additional charges
                decimal roomCharges = reservation.TotalAmount;
                decimal additionalCharges = decimal.Parse(txtAdditionalCharges.Text);
                decimal tax = (roomCharges + additionalCharges) * 0.15m; // 15% tax
                decimal discount = decimal.Parse(txtDiscount.Text);
                decimal lateCheckoutFee = decimal.Parse(txtLateCheckoutFee.Text);

                _totalAmount = roomCharges + additionalCharges + tax + lateCheckoutFee - discount;

                // Update display
                lblRoomCharges.Text = roomCharges.ToString("C2");
                lblTaxAmount.Text = tax.ToString("C2");
                lblTotalAmount.Text = _totalAmount.ToString("C2");

                // Update payment breakdown
                UpdatePaymentBreakdown();
            }
        }

        private void UpdatePaymentBreakdown()
        {
            // Simulate payment breakdown
            decimal cash = _totalAmount * 0.4m;
            decimal card = _totalAmount * 0.6m;

            lblCashAmount.Text = cash.ToString("C2");
            lblCardAmount.Text = card.ToString("C2");
            lblTotalPayment.Text = _totalAmount.ToString("C2");
        }

        private async void BtnProcessCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to check out", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvReservations.SelectedRows[0];
            var reservationId = selectedRow.Cells["colResID"].Value?.ToString();
            var guestName = selectedRow.Cells["colGuestName"].Value?.ToString();
            var roomNumber = selectedRow.Cells["colRoomNumber"].Value?.ToString();

            if (string.IsNullOrEmpty(reservationId))
            {
                MessageBox.Show("Invalid reservation selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Process check-out for {guestName} from room {roomNumber}?\n\nTotal Amount: {_totalAmount:C}",
                "Confirm Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Processing check-out for {guestName}...");

                    // Update reservation status to Checked-Out
                    var updateData = new
                    {
                        status = "Checked-Out",
                        actualCheckOutDate = DateTime.Now
                    };

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(updateData, options);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync($"reservations/{reservationId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Create payment record
                        var paymentData = new
                        {
                            reservationId = int.Parse(reservationId),
                            amount = _totalAmount,
                            paymentMethod = cmbPaymentMethod.Text,
                            description = $"Check-out payment for {guestName} - Room {roomNumber}"
                        };

                        var paymentJson = JsonSerializer.Serialize(paymentData, options);
                        var paymentContent = new StringContent(paymentJson, Encoding.UTF8, "application/json");
                        await _httpClient.PostAsync("payments", paymentContent);

                        MessageBox.Show($"Check-out processed successfully!\n\nGuest: {guestName}\nRoom: {roomNumber}\nTotal: {_totalAmount:C}",
                            "Check-Out Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear form
                        ClearForm();
                        LoadReservationsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to process check-out: {error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to print receipt", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvReservations.SelectedRows[0];
            var guestName = selectedRow.Cells["colGuestName"].Value?.ToString();
            var roomNumber = selectedRow.Cells["colRoomNumber"].Value?.ToString();

            string receipt = $"HOTEL HYATT - RECEIPT\n";
            receipt += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n";
            receipt += $"Guest: {guestName}\n";
            receipt += $"Room: {roomNumber}\n";
            receipt += "=".PadRight(40, '=') + "\n";
            receipt += $"Room Charges: {lblRoomCharges.Text}\n";
            receipt += $"Additional Charges: {txtAdditionalCharges.Text}\n";
            receipt += $"Tax: {lblTaxAmount.Text}\n";
            receipt += $"Late Checkout: {txtLateCheckoutFee.Text}\n";
            receipt += $"Discount: {txtDiscount.Text}\n";
            receipt += "=".PadRight(40, '=') + "\n";
            receipt += $"TOTAL: {lblTotalAmount.Text}\n";
            receipt += $"Payment Method: {cmbPaymentMethod.Text}\n";
            receipt += "\nThank you for staying with us!\n";

            MessageBox.Show(receipt, "Receipt Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearForm()
        {
            txtAdditionalCharges.Text = "0";
            txtDiscount.Text = "0";
            txtLateCheckoutFee.Text = "0";
            lblRoomCharges.Text = "$0.00";
            lblTaxAmount.Text = "$0.00";
            lblTotalAmount.Text = "$0.00";
            lblCashAmount.Text = "$0.00";
            lblCardAmount.Text = "$0.00";
            lblTotalPayment.Text = "$0.00";
            _totalAmount = 0;
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Check-Out Management - {message}";
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var selectedRow = dgvReservations.SelectedRows[0];
                var guestName = selectedRow.Cells["colGuestName"].Value?.ToString();
                var roomNumber = selectedRow.Cells["colRoomNumber"].Value?.ToString();

                if (!string.IsNullOrEmpty(guestName))
                {
                    txtGuestName.Text = guestName;
                    txtRoomNumber.Text = roomNumber;
                    ShowStatus($"Selected: {guestName} - Room {roomNumber}");
                }
            }
        }

        // Form model classes
        public class CheckOutReservation
        {
            public int Id { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public string RoomNumber { get; set; } = string.Empty;
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int NumberOfNights { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; } = "Checked-In";
        }

        // API model classes for deserialization
        private class ApiReservation
        {
            public int Id { get; set; }
            public int GuestId { get; set; }
            public int RoomId { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; } = "Checked-In";
        }

        private class ApiGuest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }

        private class ApiRoom
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }
    }
}