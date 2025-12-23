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
    public partial class GuestManagementForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Guest> _guests = new BindingList<Guest>();
        private int _currentGuestId = 0;
        private string _token;
        private bool _isSaving = false; // Add this to prevent multiple saves

        public GuestManagementForm(string token = "")
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
            btnUpdate.Click += btnUpdate_Click;
            dgvGuests.SelectionChanged += dgvGuests_SelectionChanged;
            dgvGuests.CellClick += dgvGuests_CellClick;
            txtSearch.KeyPress += txtSearch_KeyPress;
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
            LoadGuestsAsync();
        }

        private void SetupDataGridView()
        {
            dgvGuests.AutoGenerateColumns = false;
            dgvGuests.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvGuests.Columns.Add(colId);

            DataGridViewTextBoxColumn colFirstName = new DataGridViewTextBoxColumn();
            colFirstName.Name = "colFirstName";
            colFirstName.HeaderText = "First Name";
            colFirstName.DataPropertyName = "FirstName";
            colFirstName.Width = 120;
            dgvGuests.Columns.Add(colFirstName);

            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "colLastName";
            colLastName.HeaderText = "Last Name";
            colLastName.DataPropertyName = "LastName";
            colLastName.Width = 120;
            dgvGuests.Columns.Add(colLastName);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 150;
            dgvGuests.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.Name = "colPhone";
            colPhone.HeaderText = "Phone";
            colPhone.DataPropertyName = "Phone";
            colPhone.Width = 100;
            dgvGuests.Columns.Add(colPhone);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 80;
            dgvGuests.Columns.Add(colActions);
        }

        private async void LoadGuestsAsync()
        {
            try
            {
                ShowStatus("Loading guests...");
                var response = await _httpClient.GetAsync("guests");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var guestList = JsonSerializer.Deserialize<List<Guest>>(json, options) ?? new List<Guest>();
                    _guests = new BindingList<Guest>(guestList);

                    dgvGuests.DataSource = null;
                    dgvGuests.DataSource = _guests;
                    dgvGuests.ClearSelection();

                    ShowStatus($"Loaded {_guests.Count} guests");
                }
                else
                {
                    UseDummyGuests();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyGuests();
            }
        }

        private void UseDummyGuests()
        {
            _guests = new BindingList<Guest>
            {
                new Guest {
                    Id = 2,
                    FirstName = "Janu",
                    LastName = "Smith",
                    Email = "jane.smith@gmail.com",
                    Phone = "987-654-3210",
                    IDNumber = "ID123456"
                },
                new Guest {
                    Id = 1,
                    FirstName = "Sun",
                    LastName = "Pay",
                    Email = "Sa77@yahoo.com",
                    Phone = "+123456",
                    IDNumber = "ID654321"
                },
                new Guest {
                    Id = 3,
                    FirstName = "iKwan",
                    LastName = "Pay",
                    Email = "Rc@hotmail.com",
                    Phone = "+44777",
                    IDNumber = "ID789012"
                }
            };

            dgvGuests.DataSource = null;
            dgvGuests.DataSource = _guests;
            dgvGuests.ClearSelection();
            ShowStatus("Using sample data");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadGuestsAsync();
                return;
            }

            try
            {
                ShowStatus("Searching guests...");
                var searchQuery = txtSearch.Text.Trim();
                var response = await _httpClient.GetAsync($"guests/search?query={Uri.EscapeDataString(searchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var guestList = JsonSerializer.Deserialize<List<Guest>>(json, options) ?? new List<Guest>();
                    _guests = new BindingList<Guest>(guestList);

                    dgvGuests.DataSource = null;
                    dgvGuests.DataSource = _guests;

                    ShowStatus($"Found {_guests.Count} guests matching '{searchQuery}'");
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
            _currentGuestId = 0;
            txtFirstName.Focus();
            ShowStatus("Ready to add new guest...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Prevent multiple simultaneous saves
            if (_isSaving) return;

            _isSaving = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;

            try
            {
                if (!ValidateGuestForm())
                    return;

                var guestData = new
                {
                    firstName = txtFirstName.Text.Trim(),
                    lastName = txtLastName.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    phone = txtPhone.Text.Trim(),
                    idNumber = $"GUEST_{DateTime.Now:yyyyMMddHHmmssfff}", // More unique with milliseconds
                    idType = "National ID"
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(guestData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentGuestId == 0)
                {
                    ShowStatus("Creating new guest...");
                    response = await _httpClient.PostAsync("guests", content);
                }
                else
                {
                    ShowStatus($"Updating guest {_currentGuestId}...");
                    response = await _httpClient.PutAsync($"guests/{_currentGuestId}", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Guest saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    _currentGuestId = 0;
                    await Task.Delay(100); // Small delay to ensure clean state
                    LoadGuestsAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    var errorMessage = ParseErrorMessage(error);
                    MessageBox.Show($"Failed to save guest: {errorMessage}", "Error",
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
                btnUpdate.Enabled = true;
            }
        }

        private string ParseErrorMessage(string errorJson)
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var errorObj = JsonSerializer.Deserialize<Dictionary<string, string>>(errorJson, options);

                if (errorObj != null && errorObj.ContainsKey("error"))
                    return errorObj["error"];
                else if (errorObj != null && errorObj.ContainsKey("message"))
                    return errorObj["message"];

                return errorJson;
            }
            catch
            {
                return errorJson;
            }
        }

        private bool ValidateGuestForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a guest to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvGuests.SelectedRows[0];
            var guestId = selectedRow.Cells["colID"].Value?.ToString();
            var guestName = $"{selectedRow.Cells["colFirstName"].Value} {selectedRow.Cells["colLastName"].Value}";

            if (string.IsNullOrEmpty(guestId))
            {
                MessageBox.Show("Invalid guest selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Delete guest '{guestName}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Deleting guest {guestId}...");
                    var response = await _httpClient.DeleteAsync($"guests/{guestId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Guest deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Convert.ToInt32(guestId) == _currentGuestId)
                        {
                            _currentGuestId = 0;
                            ClearForm();
                        }

                        LoadGuestsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete guest: {response.StatusCode}\n{error}", "Error",
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
            _currentGuestId = 0;
            dgvGuests.ClearSelection();
            ShowStatus("Form cleared. Ready to add new guest...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentGuestId == 0)
            {
                MessageBox.Show("Please select a guest to update", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnSave_Click(sender, e);
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Guest Management - {message}";
        }

        private void dgvGuests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
            {
                _currentGuestId = 0;
                return;
            }

            var selectedRow = dgvGuests.SelectedRows[0];
            var guestId = selectedRow.Cells["colID"].Value;

            if (guestId != null)
            {
                _currentGuestId = Convert.ToInt32(guestId);

                if (selectedRow.DataBoundItem is Guest guest)
                {
                    txtFirstName.Text = guest.FirstName;
                    txtLastName.Text = guest.LastName;
                    txtEmail.Text = guest.Email;
                    txtPhone.Text = guest.Phone;

                    ShowStatus($"Editing guest {guest.FirstName} {guest.LastName}");
                }
            }
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvGuests.Columns["colActions"].Index)
            {
                var guestId = dgvGuests.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var guestName = $"{dgvGuests.Rows[e.RowIndex].Cells["colFirstName"].Value} {dgvGuests.Rows[e.RowIndex].Cells["colLastName"].Value}";

                if (!string.IsNullOrEmpty(guestId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvGuests.ClearSelection();
                        dgvGuests.Rows[e.RowIndex].Selected = true;
                        dgvGuests_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete guest '{guestName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting guest {guestId}...");
                                var response = await _httpClient.DeleteAsync($"guests/{guestId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Guest deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadGuestsAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete guest: {error}", "Error",
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

        public class Guest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string IDNumber { get; set; } = string.Empty;
            public string IDType { get; set; } = "National ID";
        }
    }
}