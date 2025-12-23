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
    public partial class PaymentForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Payment> _payments = new BindingList<Payment>();
        private List<Guest> _guests = new List<Guest>();
        private List<Reservation> _activeReservations = new List<Reservation>();
        private int _currentPaymentId = 0;
        private string _token;
        private bool _isSaving = false;

        public PaymentForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();
            SetupForm();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnDisplay.Click += btnDisplay_Click;
            dgvPayments.SelectionChanged += dgvPayments_SelectionChanged;
            dgvPayments.CellClick += dgvPayments_CellClick;
            txtSearch.KeyPress += txtSearch_KeyPress;
            txtFirstName.TextChanged += OnGuestNameChanged;
            txtLastName.TextChanged += OnGuestNameChanged;
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
            SetupPaymentMethodComboBox();
            LoadPaymentsAsync();
            LoadGuestsAsync();
        }

        private void SetupDataGridView()
        {
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.Columns.Clear();

            DataGridViewTextBoxColumn colPID = new DataGridViewTextBoxColumn();
            colPID.Name = "colPID";
            colPID.HeaderText = "PID";
            colPID.DataPropertyName = "Id";
            colPID.Width = 60;
            dgvPayments.Columns.Add(colPID);

            DataGridViewTextBoxColumn colFirstName = new DataGridViewTextBoxColumn();
            colFirstName.Name = "colFirstName";
            colFirstName.HeaderText = "First Name";
            colFirstName.DataPropertyName = "FirstName";
            colFirstName.Width = 120;
            dgvPayments.Columns.Add(colFirstName);

            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "colLastName";
            colLastName.HeaderText = "Last Name";
            colLastName.DataPropertyName = "LastName";
            colLastName.Width = 120;
            dgvPayments.Columns.Add(colLastName);

            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
            colAmount.Name = "colAmount";
            colAmount.HeaderText = "Amount";
            colAmount.DataPropertyName = "Amount";
            colAmount.Width = 100;
            colAmount.DefaultCellStyle.Format = "C2";
            dgvPayments.Columns.Add(colAmount);

            DataGridViewTextBoxColumn colPaymentMethod = new DataGridViewTextBoxColumn();
            colPaymentMethod.Name = "colPaymentMethod";
            colPaymentMethod.HeaderText = "Payment Method";
            colPaymentMethod.DataPropertyName = "PaymentMethod";
            colPaymentMethod.Width = 150;
            dgvPayments.Columns.Add(colPaymentMethod);

            DataGridViewTextBoxColumn colPaymentDate = new DataGridViewTextBoxColumn();
            colPaymentDate.Name = "colPaymentDate";
            colPaymentDate.HeaderText = "Payment Date";
            colPaymentDate.DataPropertyName = "PaymentDate";
            colPaymentDate.Width = 120;
            colPaymentDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvPayments.Columns.Add(colPaymentDate);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 100;
            dgvPayments.Columns.Add(colActions);
        }

        private void SetupPaymentMethodComboBox()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.AddRange(new string[] {
                "Cash",
                "Credit Card",
                "Debit Card",
                "Bank Transfer",
                "Mobile Payment"
            });
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        private async void LoadGuestsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("guests");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    _guests = JsonSerializer.Deserialize<List<Guest>>(json, options) ?? new List<Guest>();
                }
                else
                {
                    _guests = new List<Guest>
                    {
                        new Guest { Id = 1, FirstName = "Janu", LastName = "Smith" },
                        new Guest { Id = 2, FirstName = "John", LastName = "Doe" }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading guests: {ex.Message}");
                _guests = new List<Guest>
                {
                    new Guest { Id = 1, FirstName = "Janu", LastName = "Smith" },
                    new Guest { Id = 2, FirstName = "John", LastName = "Doe" }
                };
            }
        }

        private async 
        Task
LoadActiveReservationsAsync(int guestId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"reservations/active?guestId={guestId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    _activeReservations = JsonSerializer.Deserialize<List<Reservation>>(json, options) ?? new List<Reservation>();
                }
                else
                {
                    _activeReservations = new List<Reservation>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading reservations: {ex.Message}");
                _activeReservations = new List<Reservation>();
            }
        }

        private async void OnGuestNameChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                var guest = _guests.FirstOrDefault(g =>
                    g.FirstName.Equals(txtFirstName.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    g.LastName.Equals(txtLastName.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (guest != null)
                {
                    await LoadActiveReservationsAsync(guest.Id);
                    if (_activeReservations.Count == 0)
                    {
                        ShowStatus("Warning: Guest has no active reservations");
                    }
                    else
                    {
                        ShowStatus($"Found {_activeReservations.Count} active reservation(s)");
                    }
                }
            }
        }

        private async void LoadPaymentsAsync()
        {
            try
            {
                ShowStatus("Loading payments...");
                var response = await _httpClient.GetAsync("payments");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var paymentList = JsonSerializer.Deserialize<List<Payment>>(json, options) ?? new List<Payment>();
                    _payments = new BindingList<Payment>(paymentList);

                    dgvPayments.DataSource = null;
                    dgvPayments.DataSource = _payments;
                    dgvPayments.ClearSelection();

                    ShowStatus($"Loaded {_payments.Count} payments");
                }
                else
                {
                    UseDummyPayments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyPayments();
            }
        }

        private void UseDummyPayments()
        {
            _payments = new BindingList<Payment>
            {
                new Payment {
                    Id = 1,
                    FirstName = "Janu",
                    LastName = "Smith",
                    Amount = 1800.00m,
                    PaymentMethod = "Bank Transfer",
                    PaymentDate = DateTime.Now.AddDays(-2)
                },
                new Payment {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Amount = 100.00m,
                    PaymentMethod = "Credit Card",
                    PaymentDate = DateTime.Now.AddDays(-1)
                }
            };

            dgvPayments.DataSource = null;
            dgvPayments.DataSource = _payments;
            dgvPayments.ClearSelection();

            ShowStatus("Using sample data - Check API connection");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadPaymentsAsync();
                return;
            }

            try
            {
                ShowStatus("Searching payments...");
                var searchQuery = txtSearch.Text.Trim();
                var response = await _httpClient.GetAsync($"payments/search?query={Uri.EscapeDataString(searchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var paymentList = JsonSerializer.Deserialize<List<Payment>>(json, options) ?? new List<Payment>();
                    _payments = new BindingList<Payment>(paymentList);

                    dgvPayments.DataSource = null;
                    dgvPayments.DataSource = _payments;

                    ShowStatus($"Found {_payments.Count} payments matching '{searchQuery}'");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Search failed: {response.StatusCode}\n{error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentPaymentId = 0;
            txtFirstName.Focus();
            ShowStatus("Ready to add new payment...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_isSaving) return;
            _isSaving = true;
            btnSave.Enabled = false;

            try
            {
                string validationError = ValidatePaymentForm();
                if (!string.IsNullOrEmpty(validationError))
                {
                    MessageBox.Show(validationError, "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var guest = _guests.FirstOrDefault(g =>
                    g.FirstName.Equals(txtFirstName.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    g.LastName.Equals(txtLastName.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (guest == null)
                {
                    MessageBox.Show("Guest not found. Please make sure the guest exists.", "Guest Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for active reservations
                await LoadActiveReservationsAsync(guest.Id);
                if (_activeReservations.Count == 0)
                {
                    MessageBox.Show("Guest has no active reservations. Please create a reservation first.",
                        "No Active Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Use the first active reservation
                var activeReservation = _activeReservations[0];

                var paymentData = new
                {
                    guestId = guest.Id,
                    reservationId = activeReservation.Id, // Include reservation ID
                    amount = decimal.Parse(txtAmount.Text),
                    paymentMethod = cmbPaymentMethod.Text,
                    paymentDate = dtpPaymentDate.Value.ToString("yyyy-MM-dd"),
                    description = $"Payment for reservation {activeReservation.Id}"
                };

                Console.WriteLine($"Sending payment: {JsonSerializer.Serialize(paymentData)}");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(paymentData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentPaymentId == 0)
                {
                    ShowStatus("Creating new payment...");
                    response = await _httpClient.PostAsync("payments", content);
                }
                else
                {
                    ShowStatus($"Updating payment {_currentPaymentId}...");
                    response = await _httpClient.PutAsync($"payments/{_currentPaymentId}", content);
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Payment saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    _currentPaymentId = 0;
                    await Task.Delay(500);
                    LoadPaymentsAsync();
                }
                else
                {
                    var errorMessage = ParseErrorMessage(responseContent);
                    MessageBox.Show($"Failed to save payment: {errorMessage}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSaving = false;
                btnSave.Enabled = true;
            }
        }

        private string ParseErrorMessage(string errorJson)
        {
            try
            {
                if (errorJson.Contains("No active reservation"))
                    return "No active reservation found for this guest. Please create a reservation first.";

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var errorObj = JsonSerializer.Deserialize<Dictionary<string, object>>(errorJson, options);

                if (errorObj != null && errorObj.ContainsKey("error"))
                    return errorObj["error"].ToString();
                else if (errorObj != null && errorObj.ContainsKey("message"))
                    return errorObj["message"].ToString();

                return errorJson;
            }
            catch
            {
                return errorJson;
            }
        }

        private string ValidatePaymentForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                return "Please enter first name";

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                return "Please enter last name";

            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out decimal amount))
                return "Please enter a valid amount (must be a number)";

            if (amount <= 0)
                return "Amount must be greater than 0";

            return string.Empty;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvPayments.SelectedRows[0];
            var paymentId = selectedRow.Cells["colPID"].Value?.ToString();
            var guestName = $"{selectedRow.Cells["colFirstName"].Value} {selectedRow.Cells["colLastName"].Value}";

            if (string.IsNullOrEmpty(paymentId))
            {
                MessageBox.Show("Invalid payment selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Delete payment for '{guestName}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Deleting payment {paymentId}...");
                    var response = await _httpClient.DeleteAsync($"payments/{paymentId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Payment deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Convert.ToInt32(paymentId) == _currentPaymentId)
                        {
                            _currentPaymentId = 0;
                            ClearForm();
                        }

                        LoadPaymentsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete payment: {response.StatusCode}\n{error}", "Error",
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentPaymentId = 0;
            dgvPayments.ClearSelection();
            ShowStatus("Form cleared. Ready to add new payment...");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadPaymentsAsync();
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAmount.Clear();
            dtpPaymentDate.Value = DateTime.Now;
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Payment Management - {message}";
        }

        private void dgvPayments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count == 0)
            {
                _currentPaymentId = 0;
                return;
            }

            var selectedRow = dgvPayments.SelectedRows[0];
            var paymentId = selectedRow.Cells["colPID"].Value;

            if (paymentId != null)
            {
                _currentPaymentId = Convert.ToInt32(paymentId);

                if (selectedRow.DataBoundItem is Payment payment)
                {
                    txtFirstName.Text = payment.FirstName;
                    txtLastName.Text = payment.LastName;
                    txtAmount.Text = payment.Amount.ToString("F2");
                    dtpPaymentDate.Value = payment.PaymentDate;

                    if (cmbPaymentMethod.Items.Contains(payment.PaymentMethod))
                        cmbPaymentMethod.SelectedItem = payment.PaymentMethod;
                    else
                        cmbPaymentMethod.Text = payment.PaymentMethod;

                    ShowStatus($"Editing payment for {payment.FirstName} {payment.LastName}");
                }
            }
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPayments.Columns["colActions"].Index)
            {
                var paymentId = dgvPayments.Rows[e.RowIndex].Cells["colPID"].Value?.ToString();
                var guestName = $"{dgvPayments.Rows[e.RowIndex].Cells["colFirstName"].Value} {dgvPayments.Rows[e.RowIndex].Cells["colLastName"].Value}";

                if (!string.IsNullOrEmpty(paymentId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvPayments.ClearSelection();
                        dgvPayments.Rows[e.RowIndex].Selected = true;
                        dgvPayments_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete payment for '{guestName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting payment {paymentId}...");
                                var response = await _httpClient.DeleteAsync($"payments/{paymentId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Payment deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadPaymentsAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete payment: {error}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        public class Payment
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; } = string.Empty;
            public DateTime PaymentDate { get; set; }
        }

        public class Guest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }

        public class Reservation
        {
            public int Id { get; set; }
            public int GuestId { get; set; }
            public string Status { get; set; } = "Active";
        }
    }
}