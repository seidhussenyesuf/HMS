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
    public partial class RoomManagementForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Room> _rooms = new BindingList<Room>();
        private int _currentRoomId = 0;
        private List<Room> _allRooms = new List<Room>();
        private string _token;

        public RoomManagementForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();
            SetupForm();
            WireUpEvents(); // Add this line
        }

        private void WireUpEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnFilter.Click += btnFilter_Click;
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            dgvRooms.SelectionChanged += dgvRooms_SelectionChanged;
            dgvRooms.CellClick += dgvRooms_CellClick;
            txtSearch.KeyPress += txtSearch_KeyPress; // Add this line
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
            LoadRoomsAsync();
        }

        private void SetupDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.Columns.Clear();

            // Add columns
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvRooms.Columns.Add(colId);

            DataGridViewTextBoxColumn colNumber = new DataGridViewTextBoxColumn();
            colNumber.Name = "colNumber";
            colNumber.HeaderText = "Room No";
            colNumber.DataPropertyName = "RoomNumber";
            colNumber.Width = 100;
            dgvRooms.Columns.Add(colNumber);

            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.Name = "colType";
            colType.HeaderText = "Room Type";
            colType.DataPropertyName = "RoomType";
            colType.Width = 150;
            dgvRooms.Columns.Add(colType);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.Name = "colPrice";
            colPrice.HeaderText = "Price";
            colPrice.DataPropertyName = "Price";
            colPrice.Width = 100;
            colPrice.DefaultCellStyle.Format = "C2";
            dgvRooms.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colFloor = new DataGridViewTextBoxColumn();
            colFloor.Name = "colFloor";
            colFloor.HeaderText = "Floor";
            colFloor.DataPropertyName = "Floor";
            colFloor.Width = 80;
            dgvRooms.Columns.Add(colFloor);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.Width = 120;
            dgvRooms.Columns.Add(colStatus);

            DataGridViewCheckBoxColumn colAvailability = new DataGridViewCheckBoxColumn();
            colAvailability.Name = "colAvailability";
            colAvailability.HeaderText = "Available";
            colAvailability.DataPropertyName = "IsAvailable";
            colAvailability.Width = 100;
            dgvRooms.Columns.Add(colAvailability);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 100;
            dgvRooms.Columns.Add(colActions);
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

            // Status ComboBox
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] {
                "Available",
                "Occupied",
                "Maintenance",
                "Cleaning",
                "Reserved"
            });
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;

            // Filter Status ComboBox
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All Rooms");
            cmbFilterStatus.Items.AddRange(new string[] {
                "Available",
                "Occupied",
                "Maintenance",
                "Cleaning",
                "Reserved"
            });
            cmbFilterStatus.SelectedIndex = 0;

            // Floor ComboBox
            cmbFloor.Items.Clear();
            for (int i = 1; i <= 10; i++)
                cmbFloor.Items.Add(i.ToString());
            if (cmbFloor.Items.Count > 0)
                cmbFloor.SelectedIndex = 0;
        }

        private async void LoadRoomsAsync()
        {
            try
            {
                ShowStatus("Loading rooms...");
                var response = await _httpClient.GetAsync("rooms");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var roomList = JsonSerializer.Deserialize<List<Room>>(json, options) ?? new List<Room>();
                    _allRooms = roomList;
                    _rooms = new BindingList<Room>(roomList);

                    dgvRooms.DataSource = null;
                    dgvRooms.DataSource = _rooms;
                    dgvRooms.ClearSelection();

                    UpdateRoomCount();
                    ShowStatus($"Loaded {_rooms.Count} rooms");
                }
                else
                {
                    UseDummyRooms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyRooms();
            }
        }

        private void UseDummyRooms()
        {
            _allRooms = new List<Room>
            {
                new Room { Id = 1, RoomNumber = "101", RoomType = "Single", Price = 80.00m, Floor = 1, Status = "Available", IsAvailable = true },
                new Room { Id = 2, RoomNumber = "102", RoomType = "Double", Price = 120.00m, Floor = 1, Status = "Occupied", IsAvailable = false },
                new Room { Id = 3, RoomNumber = "103", RoomType = "Triple", Price = 150.00m, Floor = 1, Status = "Available", IsAvailable = true },
                new Room { Id = 4, RoomNumber = "201", RoomType = "Suite", Price = 250.00m, Floor = 2, Status = "Maintenance", IsAvailable = false },
                new Room { Id = 5, RoomNumber = "202", RoomType = "Deluxe", Price = 180.00m, Floor = 2, Status = "Available", IsAvailable = true },
                new Room { Id = 6, RoomNumber = "203", RoomType = "Executive", Price = 300.00m, Floor = 2, Status = "Reserved", IsAvailable = false },
                new Room { Id = 7, RoomNumber = "301", RoomType = "Single", Price = 85.00m, Floor = 3, Status = "Cleaning", IsAvailable = false },
                new Room { Id = 8, RoomNumber = "302", RoomType = "Double", Price = 125.00m, Floor = 3, Status = "Available", IsAvailable = true }
            };

            _rooms = new BindingList<Room>(_allRooms);
            dgvRooms.DataSource = null;
            dgvRooms.DataSource = _rooms;
            dgvRooms.ClearSelection();

            UpdateRoomCount();
            ShowStatus("Using sample data - Check API connection");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadRoomsAsync();
                return;
            }

            try
            {
                ShowStatus("Searching rooms...");
                var searchQuery = txtSearch.Text.Trim();
                var response = await _httpClient.GetAsync($"rooms/search?query={Uri.EscapeDataString(searchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var roomList = JsonSerializer.Deserialize<List<Room>>(json, options) ?? new List<Room>();
                    _rooms = new BindingList<Room>(roomList);

                    dgvRooms.DataSource = null;
                    dgvRooms.DataSource = _rooms;

                    ShowStatus($"Found {_rooms.Count} rooms matching '{searchQuery}'");
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
            _currentRoomId = 0;
            txtRoomNumber.Focus();
            ShowStatus("Ready to add new room...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Data Validation
            if (!ValidateRoomData())
                return;

            try
            {
                var roomData = new
                {
                    roomNumber = txtRoomNumber.Text.Trim(),
                    roomType = cmbRoomType.Text,
                    price = decimal.Parse(txtPrice.Text),
                    floor = int.Parse(cmbFloor.Text),
                    status = cmbStatus.Text,
                    isAvailable = cmbStatus.Text == "Available"
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(roomData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentRoomId == 0)
                {
                    ShowStatus("Creating new room...");
                    response = await _httpClient.PostAsync("rooms", content);
                }
                else
                {
                    ShowStatus($"Updating room {_currentRoomId}...");
                    response = await _httpClient.PutAsync($"rooms/{_currentRoomId}", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Room saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    _currentRoomId = 0;
                    LoadRoomsAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to save room: {error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRoomData()
        {
            // Validate Room Number
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Please enter room number", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumber.Focus();
                return false;
            }

            // Validate Room Type
            if (string.IsNullOrWhiteSpace(cmbRoomType.Text))
            {
                MessageBox.Show("Please select room type", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoomType.Focus();
                return false;
            }

            // Validate Price
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("Price must be greater than 0", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            // Validate Status
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please select room status", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentRoomId == 0)
            {
                MessageBox.Show("Please select a room to update", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnSave_Click(sender, e);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvRooms.SelectedRows[0];
            var roomId = selectedRow.Cells["colID"].Value?.ToString();
            var roomNumber = selectedRow.Cells["colNumber"].Value?.ToString();

            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Invalid room selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Delete room '{roomNumber}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Deleting room {roomId}...");
                    var response = await _httpClient.DeleteAsync($"rooms/{roomId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Room deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Convert.ToInt32(roomId) == _currentRoomId)
                        {
                            _currentRoomId = 0;
                            ClearForm();
                        }

                        LoadRoomsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete room: {response.StatusCode}\n{error}", "Error",
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
            _currentRoomId = 0;
            dgvRooms.ClearSelection();
            ShowStatus("Form cleared. Ready to add new room...");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var selectedStatus = cmbFilterStatus.Text;

            if (selectedStatus == "All Rooms")
            {
                _rooms = new BindingList<Room>(_allRooms);
            }
            else
            {
                var filteredRooms = _allRooms.Where(r => r.Status == selectedStatus).ToList();
                _rooms = new BindingList<Room>(filteredRooms);
            }

            dgvRooms.DataSource = null;
            dgvRooms.DataSource = _rooms;
            UpdateRoomCount();
            ShowStatus($"Showing {_rooms.Count} rooms ({selectedStatus})");
        }

        private void ClearForm()
        {
            txtRoomNumber.Clear();
            txtPrice.Clear();
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
            if (cmbFloor.Items.Count > 0)
                cmbFloor.SelectedIndex = 0;
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Room Management - {message}";
        }

        private void UpdateRoomCount()
        {
            int available = _allRooms.Count(r => r.Status == "Available");
            int occupied = _allRooms.Count(r => r.Status == "Occupied");
            int total = _allRooms.Count;

            lblRoomCount.Text = $"Total: {total} | Available: {available} | Occupied: {occupied}";
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                _currentRoomId = 0;
                return;
            }

            var selectedRow = dgvRooms.SelectedRows[0];
            var roomId = selectedRow.Cells["colID"].Value;

            if (roomId != null)
            {
                _currentRoomId = Convert.ToInt32(roomId);

                if (selectedRow.DataBoundItem is Room room)
                {
                    txtRoomNumber.Text = room.RoomNumber;
                    txtPrice.Text = room.Price.ToString("F2");

                    if (cmbRoomType.Items.Contains(room.RoomType))
                        cmbRoomType.SelectedItem = room.RoomType;
                    else
                        cmbRoomType.Text = room.RoomType;

                    if (cmbStatus.Items.Contains(room.Status))
                        cmbStatus.SelectedItem = room.Status;
                    else
                        cmbStatus.Text = room.Status;

                    if (cmbFloor.Items.Contains(room.Floor.ToString()))
                        cmbFloor.SelectedItem = room.Floor.ToString();
                    else
                        cmbFloor.Text = room.Floor.ToString();

                    ShowStatus($"Editing room {room.RoomNumber}");
                }
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvRooms.Columns["colActions"].Index)
            {
                var roomId = dgvRooms.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var roomNumber = dgvRooms.Rows[e.RowIndex].Cells["colNumber"].Value?.ToString();

                if (!string.IsNullOrEmpty(roomId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvRooms.ClearSelection();
                        dgvRooms.Rows[e.RowIndex].Selected = true;
                        dgvRooms_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete room '{roomNumber}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting room {roomId}...");
                                var response = await _httpClient.DeleteAsync($"rooms/{roomId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Room deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadRoomsAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete room: {error}", "Error",
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

        // Model class with OOP
        public class Room
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Floor { get; set; }
            public string Status { get; set; } = "Available";
            public bool IsAvailable { get; set; } = true;

            // OOP: Method to calculate total cost for stay duration
            public decimal CalculateTotalCost(int nights)
            {
                return Price * nights;
            }

            // OOP: Method to check if room is available for booking
            public bool CanBook()
            {
                return IsAvailable && Status == "Available";
            }

            // OOP: Method to update status
            public void UpdateStatus(string newStatus)
            {
                Status = newStatus;
                IsAvailable = (newStatus == "Available");
            }
        }
    }
}