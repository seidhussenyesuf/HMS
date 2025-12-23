using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class ReservationForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Reservation> _reservations = new BindingList<Reservation>();
        private int _currentReservationId = 0;
        private List<Guest> _guests = new List<Guest>();
        private List<Room> _rooms = new List<Room>();
        private string _token;
        private bool _isSaving = false;

        public ReservationForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();
            SetupForm();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnSave.Click += btnSave_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDisplay.Click += btnDisplay_Click;
            dgvReservations.SelectionChanged += dgvReservations_SelectionChanged;
            dgvReservations.CellClick += dgvReservations_CellClick;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
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
            LoadReservationsAsync();
            LoadGuestsAsync();
            LoadRoomsAsync();
        }

        private void SetupDataGridView()
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "Id";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvReservations.Columns.Add(colId);

            DataGridViewTextBoxColumn colGuestName = new DataGridViewTextBoxColumn();
            colGuestName.Name = "colGuestName";
            colGuestName.HeaderText = "GuestName";
            colGuestName.DataPropertyName = "GuestName";
            colGuestName.Width = 120;
            dgvReservations.Columns.Add(colGuestName);

            DataGridViewTextBoxColumn colRoomNo = new DataGridViewTextBoxColumn();
            colRoomNo.Name = "colRoomNo";
            colRoomNo.HeaderText = "Room_No";
            colRoomNo.DataPropertyName = "RoomNumber";
            colRoomNo.Width = 80;
            dgvReservations.Columns.Add(colRoomNo);

            DataGridViewTextBoxColumn colRoomType = new DataGridViewTextBoxColumn();
            colRoomType.Name = "colRoomType";
            colRoomType.HeaderText = "Room_Type";
            colRoomType.DataPropertyName = "RoomType";
            colRoomType.Width = 100;
            dgvReservations.Columns.Add(colRoomType);

            DataGridViewTextBoxColumn colHotelCode = new DataGridViewTextBoxColumn();
            colHotelCode.Name = "colHotelCode";
            colHotelCode.HeaderText = "Hotel_Code";
            colHotelCode.DataPropertyName = "HotelCode";
            colHotelCode.Width = 100;
            dgvReservations.Columns.Add(colHotelCode);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 80;
            dgvReservations.Columns.Add(colActions);
        }

        private void SetupComboBoxes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.AddRange(new string[] {
                "Single",
                "Double",
                "Triple",
                "Suite",
                "Deluxe"
            });
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;

            cmbRoomNo.Items.Clear();

            // Hotel Code ComboBox - Fixed to match your screenshot
            cmbHotelCode.Items.Clear();
            cmbHotelCode.Items.AddRange(new string[] {
                "HYATT001",
                "HYATT002",
                "HYATT003",
                "HYATT004"
            });

            if (cmbHotelCode.Items.Count > 0)
                cmbHotelCode.SelectedIndex = 0;
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

                    cmbGuestName.Items.Clear();
                    cmbGuestName.Items.Add("-- Select Guest --");
                    foreach (var guest in _guests)
                    {
                        cmbGuestName.Items.Add($"{guest.FirstName} {guest.LastName}");
                    }
                    if (cmbGuestName.Items.Count > 0)
                        cmbGuestName.SelectedIndex = 0;
                }
                else
                {
                    _guests = new List<Guest>
                    {
                        new Guest { Id = 1, FirstName = "Janu", LastName = "Smith" },
                        new Guest { Id = 2, FirstName = "John", LastName = "Doe" }
                    };

                    cmbGuestName.Items.Clear();
                    cmbGuestName.Items.Add("-- Select Guest --");
                    foreach (var guest in _guests)
                    {
                        cmbGuestName.Items.Add($"{guest.FirstName} {guest.LastName}");
                    }
                    if (cmbGuestName.Items.Count > 0)
                        cmbGuestName.SelectedIndex = 0;
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

                cmbGuestName.Items.Clear();
                cmbGuestName.Items.Add("-- Select Guest --");
                foreach (var guest in _guests)
                {
                    cmbGuestName.Items.Add($"{guest.FirstName} {guest.LastName}");
                }
                if (cmbGuestName.Items.Count > 0)
                    cmbGuestName.SelectedIndex = 0;
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

                    UpdateRoomNumbers(cmbRoomType.Text);
                }
                else
                {
                    _rooms = new List<Room>
                    {
                        new Room { Id = 1, RoomNumber = "101", RoomType = "Single", Status = "Available", Price = 100.00m },
                        new Room { Id = 2, RoomNumber = "102", RoomType = "Single", Status = "Available", Price = 100.00m },
                        new Room { Id = 3, RoomNumber = "201", RoomType = "Double", Status = "Available", Price = 150.00m },
                        new Room { Id = 4, RoomNumber = "202", RoomType = "Double", Status = "Available", Price = 150.00m },
                        new Room { Id = 5, RoomNumber = "301", RoomType = "Triple", Status = "Available", Price = 200.00m },
                        new Room { Id = 6, RoomNumber = "302", RoomType = "Triple", Status = "Available", Price = 200.00m }
                    };

                    UpdateRoomNumbers("Single");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading rooms: {ex.Message}");
                _rooms = new List<Room>
                {
                    new Room { Id = 1, RoomNumber = "101", RoomType = "Single", Status = "Available", Price = 100.00m },
                    new Room { Id = 2, RoomNumber = "102", RoomType = "Single", Status = "Available", Price = 100.00m },
                    new Room { Id = 3, RoomNumber = "201", RoomType = "Double", Status = "Available", Price = 150.00m },
                    new Room { Id = 4, RoomNumber = "202", RoomType = "Double", Status = "Available", Price = 150.00m },
                    new Room { Id = 5, RoomNumber = "301", RoomType = "Triple", Status = "Available", Price = 200.00m },
                    new Room { Id = 6, RoomNumber = "302", RoomType = "Triple", Status = "Available", Price = 200.00m }
                };

                UpdateRoomNumbers("Single");
            }
        }

        private async void LoadReservationsAsync()
        {
            try
            {
                ShowStatus("Loading reservations...");
                var response = await _httpClient.GetAsync("reservations");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var reservationList = JsonSerializer.Deserialize<List<Reservation>>(json, options) ?? new List<Reservation>();
                    _reservations = new BindingList<Reservation>(reservationList);

                    dgvReservations.DataSource = null;
                    dgvReservations.DataSource = _reservations;
                    dgvReservations.ClearSelection();

                    ShowStatus($"Loaded {_reservations.Count} reservations");
                }
                else
                {
                    UseDummyReservations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseDummyReservations();
            }
        }

        private void UseDummyReservations()
        {
            _reservations = new BindingList<Reservation>
            {
                new Reservation {
                    Id = 1,
                    GuestName = "Janu Smith",
                    RoomNumber = "101",
                    RoomType = "Single",
                    HotelCode = "HYATT001",
                    Status = "Confirmed"
                },
                new Reservation {
                    Id = 2,
                    GuestName = "John Doe",
                    RoomNumber = "201",
                    RoomType = "Double",
                    HotelCode = "HYATT002",
                    Status = "Confirmed"
                }
            };

            dgvReservations.DataSource = null;
            dgvReservations.DataSource = _reservations;
            dgvReservations.ClearSelection();

            ShowStatus("Using sample data - Check API connection");
        }

        private void UpdateRoomNumbers(string roomType)
        {
            cmbRoomNo.Items.Clear();
            var availableRooms = _rooms.Where(r => r.RoomType == roomType && r.Status == "Available").ToList();

            if (availableRooms.Count == 0)
            {
                cmbRoomNo.Items.Add("No rooms available");
                cmbRoomNo.SelectedIndex = 0;
            }
            else
            {
                foreach (var room in availableRooms)
                {
                    cmbRoomNo.Items.Add(room.RoomNumber);
                }
                cmbRoomNo.SelectedIndex = 0;
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers(cmbRoomType.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentReservationId = 0;
            cmbGuestName.Focus();
            ShowStatus("Ready to create new reservation...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_isSaving) return;
            _isSaving = true;
            btnSave.Enabled = false;

            try
            {
                if (!ValidateReservationForm())
                    return;

                // Get guest ID from name
                if (cmbGuestName.SelectedIndex == 0 || cmbGuestName.Text == "-- Select Guest --")
                {
                    MessageBox.Show("Please select a guest", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var guestNameParts = cmbGuestName.Text.Split(' ', 2);
                var guest = _guests.FirstOrDefault(g =>
                    g.FirstName == guestNameParts[0] &&
                    g.LastName == (guestNameParts.Length > 1 ? guestNameParts[1] : ""));

                if (guest == null)
                {
                    MessageBox.Show("Guest not found. Please select a valid guest.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if room exists
                var selectedRoom = _rooms.FirstOrDefault(r => r.RoomNumber == cmbRoomNo.Text);
                if (selectedRoom == null || selectedRoom.Status != "Available")
                {
                    MessageBox.Show("Selected room is not available or doesn't exist.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate nights and total amount
                var checkIn = dtpCheckIn.Value;
                var checkOut = dtpCheckOut.Value;
                var nights = (checkOut - checkIn).TotalDays;
                if (nights < 1) nights = 1;
                var totalAmount = selectedRoom.Price * (decimal)nights;

                // Send COMPLETE reservation data matching your API requirements
                var reservationData = new
                {
                    guestId = guest.Id,
                    roomId = selectedRoom.Id,
                    checkInDate = checkIn.ToString("yyyy-MM-dd"),
                    checkOutDate = checkOut.ToString("yyyy-MM-dd"),
                    numberOfAdults = 1, // Default value
                    numberOfChildren = 0, // Default value
                    totalAmount = totalAmount,
                    specialRequests = "" // Empty string as required
                };

                Console.WriteLine($"Sending reservation data: {JsonSerializer.Serialize(reservationData)}");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(reservationData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentReservationId == 0)
                {
                    ShowStatus("Creating new reservation...");
                    response = await _httpClient.PostAsync("reservations", content);
                }
                else
                {
                    ShowStatus($"Updating reservation {_currentReservationId}...");
                    response = await _httpClient.PutAsync($"reservations/{_currentReservationId}", content);
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reservation saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    _currentReservationId = 0;
                    await Task.Delay(500);
                    LoadReservationsAsync();
                    LoadRoomsAsync(); // Refresh room availability
                }
                else
                {
                    var errorMessage = ParseErrorMessage(responseContent);
                    MessageBox.Show($"Failed to save reservation: {errorMessage}", "Error",
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
                if (errorJson.Contains("given key was not present") || errorJson.Contains("Required field"))
                    return "Required field missing in request";

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

        private bool ValidateReservationForm()
        {
            if (cmbGuestName.SelectedIndex == 0 || cmbGuestName.Text == "-- Select Guest --")
            {
                MessageBox.Show("Please select a guest", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGuestName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbRoomType.Text))
            {
                MessageBox.Show("Please select room type", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoomType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbRoomNo.Text) || cmbRoomNo.Text == "No rooms available")
            {
                MessageBox.Show("Please select a valid room number", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoomNo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbHotelCode.Text))
            {
                MessageBox.Show("Please select hotel code", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHotelCode.Focus();
                return false;
            }

            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Check-in date must be before check-out date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpCheckIn.Focus();
                return false;
            }

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentReservationId == 0)
            {
                MessageBox.Show("Please select a reservation to update", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnSave_Click(sender, e);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadReservationsAsync();
        }

        private void ClearForm()
        {
            if (cmbGuestName.Items.Count > 0)
                cmbGuestName.SelectedIndex = 0;
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
            if (cmbHotelCode.Items.Count > 0)
                cmbHotelCode.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            UpdateRoomNumbers(cmbRoomType.Text);
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Reservation Management - {message}";
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                _currentReservationId = 0;
                return;
            }

            var selectedRow = dgvReservations.SelectedRows[0];
            var reservationId = selectedRow.Cells["colID"].Value;

            if (reservationId != null)
            {
                _currentReservationId = Convert.ToInt32(reservationId);

                if (selectedRow.DataBoundItem is Reservation reservation)
                {
                    cmbGuestName.Text = reservation.GuestName;
                    cmbRoomType.Text = reservation.RoomType;
                    cmbRoomNo.Text = reservation.RoomNumber;
                    cmbHotelCode.Text = reservation.HotelCode;

                    ShowStatus($"Editing reservation for {reservation.GuestName}");
                }
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvReservations.Columns["colActions"].Index)
            {
                var reservationId = dgvReservations.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var guestName = dgvReservations.Rows[e.RowIndex].Cells["colGuestName"].Value?.ToString();

                if (!string.IsNullOrEmpty(reservationId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvReservations.ClearSelection();
                        dgvReservations.Rows[e.RowIndex].Selected = true;
                        dgvReservations_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete reservation for '{guestName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting reservation {reservationId}...");
                                var response = await _httpClient.DeleteAsync($"reservations/{reservationId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Reservation deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadReservationsAsync();
                                    LoadRoomsAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete reservation: {error}", "Error",
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

        public class Reservation
        {
            public int Id { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public string HotelCode { get; set; } = string.Empty;
            public string Status { get; set; } = "Confirmed";
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
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
            public string Status { get; set; } = "Available";
            public decimal Price { get; set; } = 100.00m; // Added price field
        }
    }
}