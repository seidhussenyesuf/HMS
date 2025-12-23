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
    public partial class BillManagementForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Bill> _bills = new BindingList<Bill>();
        private int _currentBillId = 0;
        private List<Guest> _guests = new List<Guest>();
        private List<Room> _rooms = new List<Room>();
        private string _token;

        public BillManagementForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();

            // Wire up button events
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDisplay.Click += btnDisplay_Click;

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
            SetupComboBoxes();
            LoadBillsAsync();
            LoadGuestsAsync();
            LoadRoomsAsync();
            CalculateTotalBill();

            // Wire up text changed events for real-time calculation
            txtNights.TextChanged += txtNights_TextChanged;
            txtRoomPrice.TextChanged += txtRoomPrice_TextChanged;
            txtAdditionalCharges.TextChanged += txtAdditionalCharges_TextChanged;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
        }

        private void SetupDataGridView()
        {
            dgvBills.AutoGenerateColumns = false;
            dgvBills.Columns.Clear();

            // Add columns
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvBills.Columns.Add(colId);

            DataGridViewTextBoxColumn colGuestName = new DataGridViewTextBoxColumn();
            colGuestName.Name = "colGuestName";
            colGuestName.HeaderText = "Guest Name";
            colGuestName.DataPropertyName = "GuestName";
            colGuestName.Width = 150;
            dgvBills.Columns.Add(colGuestName);

            DataGridViewTextBoxColumn colRoomType = new DataGridViewTextBoxColumn();
            colRoomType.Name = "colRoomType";
            colRoomType.HeaderText = "Room Type";
            colRoomType.DataPropertyName = "RoomType";
            colRoomType.Width = 100;
            dgvBills.Columns.Add(colRoomType);

            DataGridViewTextBoxColumn colNights = new DataGridViewTextBoxColumn();
            colNights.Name = "colNights";
            colNights.HeaderText = "Nights";
            colNights.DataPropertyName = "NumberOfNights";
            colNights.Width = 70;
            dgvBills.Columns.Add(colNights);

            DataGridViewTextBoxColumn colRoomCharges = new DataGridViewTextBoxColumn();
            colRoomCharges.Name = "colRoomCharges";
            colRoomCharges.HeaderText = "Room Charges";
            colRoomCharges.DataPropertyName = "RoomCharges";
            colRoomCharges.Width = 120;
            colRoomCharges.DefaultCellStyle.Format = "C2";
            dgvBills.Columns.Add(colRoomCharges);

            DataGridViewTextBoxColumn colAdditional = new DataGridViewTextBoxColumn();
            colAdditional.Name = "colAdditional";
            colAdditional.HeaderText = "Additional";
            colAdditional.DataPropertyName = "AdditionalCharges";
            colAdditional.Width = 100;
            colAdditional.DefaultCellStyle.Format = "C2";
            dgvBills.Columns.Add(colAdditional);

            DataGridViewTextBoxColumn colTax = new DataGridViewTextBoxColumn();
            colTax.Name = "colTax";
            colTax.HeaderText = "Tax";
            colTax.DataPropertyName = "TaxAmount";
            colTax.Width = 80;
            colTax.DefaultCellStyle.Format = "C2";
            dgvBills.Columns.Add(colTax);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "colTotal";
            colTotal.HeaderText = "Total Bill";
            colTotal.DataPropertyName = "TotalAmount";
            colTotal.Width = 120;
            colTotal.DefaultCellStyle.Format = "C2";
            colTotal.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvBills.Columns.Add(colTotal);

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "colDate";
            colDate.HeaderText = "Date";
            colDate.DataPropertyName = "BillDate";
            colDate.Width = 100;
            colDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvBills.Columns.Add(colDate);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 100;
            dgvBills.Columns.Add(colActions);
        }

        private void SetupComboBoxes()
        {
            // Room Type ComboBox
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.AddRange(new string[] {
                "Single",
                "Double",
                "Triple",
                "Suite",
                "Deluxe",
                "Executive"
            });
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;

            // Guest ComboBox
            cmbGuest.DropDownStyle = ComboBoxStyle.DropDownList;
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

                    cmbGuest.Items.Clear();
                    foreach (var guest in _guests)
                    {
                        cmbGuest.Items.Add($"{guest.FirstName} {guest.LastName} (ID: {guest.Id})");
                    }
                    if (cmbGuest.Items.Count > 0)
                        cmbGuest.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading guests: {ex.Message}");
                // Add sample guests for demo
                _guests = new List<Guest>
                {
                    new Guest { Id = 1, FirstName = "John", LastName = "Smith" },
                    new Guest { Id = 2, FirstName = "Maria", LastName = "Garcia" },
                    new Guest { Id = 3, FirstName = "David", LastName = "Chen" }
                };

                cmbGuest.Items.Clear();
                foreach (var guest in _guests)
                {
                    cmbGuest.Items.Add($"{guest.FirstName} {guest.LastName} (ID: {guest.Id})");
                }
                if (cmbGuest.Items.Count > 0)
                    cmbGuest.SelectedIndex = 0;
            }
        }

        private async void LoadRoomsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("rooms");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    _rooms = JsonSerializer.Deserialize<List<Room>>(json, options) ?? new List<Room>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading rooms: {ex.Message}");
                // Add sample rooms for demo
                _rooms = new List<Room>
                {
                    new Room { Id = 1, RoomNumber = "101", RoomType = "Single", Price = 80.00m },
                    new Room { Id = 2, RoomNumber = "102", RoomType = "Double", Price = 120.00m },
                    new Room { Id = 3, RoomNumber = "103", RoomType = "Suite", Price = 250.00m }
                };
            }
        }

        private async void LoadBillsAsync()
        {
            try
            {
                ShowStatus("Loading bills...");
                var response = await _httpClient.GetAsync("payments");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var paymentList = JsonSerializer.Deserialize<List<PaymentResponse>>(json, options) ?? new List<PaymentResponse>();

                    // Convert payments to bills
                    _bills = new BindingList<Bill>();
                    foreach (var payment in paymentList)
                    {
                        _bills.Add(new Bill
                        {
                            Id = payment.Id,
                            GuestName = $"{payment.FirstName} {payment.LastName}",
                            RoomType = "N/A", // We don't have room info in payment
                            NumberOfNights = 1,
                            RoomCharges = payment.Amount * 0.7m, // Assuming 70% is room charges
                            AdditionalCharges = payment.Amount * 0.2m, // 20% additional
                            TaxAmount = payment.Amount * 0.1m, // 10% tax
                            TotalAmount = payment.Amount,
                            BillDate = payment.PaymentDate
                        });
                    }

                    dgvBills.DataSource = null;
                    dgvBills.DataSource = _bills;
                    dgvBills.ClearSelection();

                    ShowStatus($"Loaded {_bills.Count} bills");
                }
                else
                {
                    UseDummyBills();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyBills();
            }
        }

        private void UseDummyBills()
        {
            _bills = new BindingList<Bill>
            {
                new Bill {
                    Id = 1,
                    GuestName = "John Smith",
                    RoomType = "Single",
                    NumberOfNights = 3,
                    RoomCharges = 240.00m, // 80 * 3
                    AdditionalCharges = 80.00m,
                    TaxAmount = 32.00m,
                    Discount = 0.00m,
                    TotalAmount = 352.00m,
                    BillDate = DateTime.Now.AddDays(-2)
                },
                new Bill {
                    Id = 2,
                    GuestName = "Maria Garcia",
                    RoomType = "Double",
                    NumberOfNights = 2,
                    RoomCharges = 240.00m, // 120 * 2
                    AdditionalCharges = 50.00m,
                    TaxAmount = 29.00m,
                    Discount = 10.00m,
                    TotalAmount = 309.00m,
                    BillDate = DateTime.Now.AddDays(-1)
                },
                new Bill {
                    Id = 3,
                    GuestName = "David Chen",
                    RoomType = "Suite",
                    NumberOfNights = 5,
                    RoomCharges = 1250.00m, // 250 * 5
                    AdditionalCharges = 150.00m,
                    TaxAmount = 140.00m,
                    Discount = 50.00m,
                    TotalAmount = 1490.00m,
                    BillDate = DateTime.Now
                }
            };

            dgvBills.DataSource = null;
            dgvBills.DataSource = _bills;
            dgvBills.ClearSelection();

            ShowStatus("Using sample data - Check API connection");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentBillId = 0;
            cmbGuest.Focus();
            ShowStatus("Ready to create new bill...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string validationError = ValidateBillForm();
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CalculateTotalBill();

                // Get selected guest ID
                int guestId = 0;
                if (cmbGuest.SelectedItem != null)
                {
                    var guestName = cmbGuest.SelectedItem.ToString();
                    var match = System.Text.RegularExpressions.Regex.Match(guestName, @"ID: (\d+)");
                    if (match.Success)
                        guestId = int.Parse(match.Groups[1].Value);
                }

                var billData = new
                {
                    guestId = guestId,
                    amount = decimal.Parse(txtTotalAmount.Text.Replace("$", "").Replace(",", "")),
                    paymentMethod = "Cash",
                    description = $"Bill for {cmbGuest.Text} - Room: {cmbRoomType.Text}, Nights: {txtNights.Text}"
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(billData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentBillId == 0)
                {
                    ShowStatus("Creating new bill...");
                    response = await _httpClient.PostAsync("payments", content);
                }
                else
                {
                    ShowStatus($"Updating bill {_currentBillId}...");
                    response = await _httpClient.PutAsync($"payments/{_currentBillId}", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bill saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    _currentBillId = 0;
                    LoadBillsAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to save bill: {error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateBillForm()
        {
            if (cmbGuest.SelectedIndex == -1)
                return "Please select a guest";

            if (string.IsNullOrWhiteSpace(cmbRoomType.Text))
                return "Please select room type";

            if (string.IsNullOrWhiteSpace(txtNights.Text) || !int.TryParse(txtNights.Text, out int nights))
                return "Please enter a valid number of nights (must be a number)";

            if (nights <= 0)
                return "Number of nights must be greater than 0";

            if (string.IsNullOrWhiteSpace(txtRoomPrice.Text) || !decimal.TryParse(txtRoomPrice.Text, out decimal roomPrice))
                return "Please enter a valid room price (must be a number)";

            if (roomPrice <= 0)
                return "Room price must be greater than 0";

            return string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadBillsAsync();
        }

        private void CalculateTotalBill()
        {
            try
            {
                // Room Charges = Nights × Room Price
                decimal roomCharges = 0;
                if (int.TryParse(txtNights.Text, out int nights) &&
                    decimal.TryParse(txtRoomPrice.Text, out decimal roomPrice))
                {
                    roomCharges = nights * roomPrice;
                    txtRoomCharges.Text = roomCharges.ToString("C2");
                }

                // Additional Charges
                decimal additionalCharges = 0;
                decimal.TryParse(txtAdditionalCharges.Text.Replace("$", "").Replace(",", ""), out additionalCharges);

                // Tax (15% of room charges + additional)
                decimal tax = (roomCharges + additionalCharges) * 0.15m;
                txtTax.Text = tax.ToString("C2");

                // Discount
                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text.Replace("$", "").Replace(",", ""), out discount);

                // Total Amount = Room Charges + Additional + Tax - Discount
                decimal totalAmount = roomCharges + additionalCharges + tax - discount;
                txtTotalAmount.Text = totalAmount.ToString("C2");
            }
            catch (Exception)
            {
                txtRoomCharges.Text = "$0.00";
                txtTax.Text = "$0.00";
                txtTotalAmount.Text = "$0.00";
            }
        }

        private void txtNights_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalBill();
        }

        private void txtRoomPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalBill();
        }

        private void txtAdditionalCharges_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalBill();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalBill();
        }

        private void ClearForm()
        {
            if (cmbGuest.Items.Count > 0)
                cmbGuest.SelectedIndex = 0;
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
            txtNights.Text = "1";
            txtRoomPrice.Text = "100";
            txtRoomCharges.Text = "$100.00";
            txtAdditionalCharges.Text = "$0.00";
            txtTax.Text = "$15.00";
            txtDiscount.Text = "$0.00";
            txtTotalAmount.Text = "$115.00";
            txtDescription.Clear();
        }

        private void ShowStatus(string message)
        {
            this.Text = $"💰 Bill Management - {message}";
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count == 0)
            {
                _currentBillId = 0;
                return;
            }

            var selectedRow = dgvBills.SelectedRows[0];
            var billId = selectedRow.Cells["colID"].Value;

            if (billId != null)
            {
                _currentBillId = Convert.ToInt32(billId);

                if (selectedRow.DataBoundItem is Bill bill)
                {
                    // Find guest in combo box
                    var guestItem = cmbGuest.Items.Cast<string>()
                        .FirstOrDefault(item => item.Contains(bill.GuestName.Split(' ')[0]));
                    if (guestItem != null)
                        cmbGuest.SelectedItem = guestItem;

                    cmbRoomType.Text = bill.RoomType;
                    txtNights.Text = bill.NumberOfNights.ToString();

                    // Calculate room price
                    decimal roomPrice = bill.NumberOfNights > 0 ? bill.RoomCharges / bill.NumberOfNights : 0;
                    txtRoomPrice.Text = roomPrice.ToString("F2");

                    txtRoomCharges.Text = bill.RoomCharges.ToString("C2");
                    txtAdditionalCharges.Text = bill.AdditionalCharges.ToString("C2");
                    txtTax.Text = bill.TaxAmount.ToString("C2");
                    txtDiscount.Text = bill.Discount.ToString("C2");
                    txtTotalAmount.Text = bill.TotalAmount.ToString("C2");

                    ShowStatus($"Editing bill for {bill.GuestName}");
                }
            }
        }

        private void dgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBills.Columns["colActions"].Index)
            {
                var billId = dgvBills.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var guestName = dgvBills.Rows[e.RowIndex].Cells["colGuestName"].Value?.ToString();

                if (!string.IsNullOrEmpty(billId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvBills.ClearSelection();
                        dgvBills.Rows[e.RowIndex].Selected = true;
                        dgvBills_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete bill for '{guestName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting bill {billId}...");
                                var response = await _httpClient.DeleteAsync($"payments/{billId}");

                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Bill deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadBillsAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete bill: {error}", "Error",
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

        // Model classes
        public class Bill
        {
            public int Id { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public int NumberOfNights { get; set; }
            public decimal RoomCharges { get; set; }
            public decimal AdditionalCharges { get; set; }
            public decimal TaxAmount { get; set; }
            public decimal Discount { get; set; }
            public decimal TotalAmount { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime BillDate { get; set; }
        }

        public class Guest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }

        public class Room
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }

        private class PaymentResponse
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; } = string.Empty;
            public DateTime PaymentDate { get; set; }
            public string Description { get; set; } = string.Empty;
        }
    }
}