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
    public partial class CheckInForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Reservation> _reservations = new BindingList<Reservation>();
        private BindingList<Guest> _guests = new BindingList<Guest>();
        private BindingList<Room> _rooms = new BindingList<Room>();
        private string _token;
        private int _currentReservationId = 0;

        public CheckInForm(string token = "")
        {
            InitializeComponent();
            _token = token;
            SetupHttpClient();

            // Wire up button events
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckOut.Click += btnCheckOut_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnNewReservation.Click += btnNewReservation_Click;

            SetupForm();
            LoadDataAsync();
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
            SetupDataGridViews();
            SetupComboBoxes();
        }

        private async void LoadDataAsync()
        {
            await LoadReservationsAsync();
            await LoadGuestsAsync();
            await LoadRoomsAsync();
        }

        private void SetupDataGridViews()
        {
            // Setup Reservations DataGridView
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.Columns.Clear();

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

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.Width = 100;
            dgvReservations.Columns.Add(colStatus);

            // Setup Available Rooms DataGridView
            dgvAvailableRooms.AutoGenerateColumns = false;
            dgvAvailableRooms.Columns.Clear();

            DataGridViewTextBoxColumn colRoomId = new DataGridViewTextBoxColumn();
            colRoomId.Name = "colRoomID";
            colRoomId.HeaderText = "Room ID";
            colRoomId.DataPropertyName = "Id";
            colRoomId.Width = 70;
            dgvAvailableRooms.Columns.Add(colRoomId);

            DataGridViewTextBoxColumn colRoomNo = new DataGridViewTextBoxColumn();
            colRoomNo.Name = "colRoomNo";
            colRoomNo.HeaderText = "Room No";
            colRoomNo.DataPropertyName = "RoomNumber";
            colRoomNo.Width = 80;
            dgvAvailableRooms.Columns.Add(colRoomNo);

            DataGridViewTextBoxColumn colRoomType = new DataGridViewTextBoxColumn();
            colRoomType.Name = "colRoomType";
            colRoomType.HeaderText = "Type";
            colRoomType.DataPropertyName = "RoomType";
            colRoomType.Width = 100;
            dgvAvailableRooms.Columns.Add(colRoomType);

            DataGridViewTextBoxColumn colRoomPrice = new DataGridViewTextBoxColumn();
            colRoomPrice.Name = "colRoomPrice";
            colRoomPrice.HeaderText = "Price";
            colRoomPrice.DataPropertyName = "Price";
            colRoomPrice.Width = 80;
            colRoomPrice.DefaultCellStyle.Format = "C2";
            dgvAvailableRooms.Columns.Add(colRoomPrice);

            DataGridViewTextBoxColumn colFloor = new DataGridViewTextBoxColumn();
            colFloor.Name = "colFloor";
            colFloor.HeaderText = "Floor";
            colFloor.DataPropertyName = "Floor";
            colFloor.Width = 60;
            dgvAvailableRooms.Columns.Add(colFloor);
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
                "Deluxe"
            });
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
        }

        private async Task LoadReservationsAsync()
        {
            try
            {
                ShowStatus("Loading reservations...");
                var response = await _httpClient.GetAsync("reservations");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var reservationList = JsonSerializer.Deserialize<List<ApiReservation>>(json, options) ?? new List<ApiReservation>();

                    // Convert to form reservations
                    var formReservations = new List<Reservation>();
                    foreach (var apiRes in reservationList)
                    {
                        if (apiRes.Status == "Confirmed" || apiRes.Status == "Checked-In")
                        {
                            formReservations.Add(new Reservation
                            {
                                Id = apiRes.Id,
                                GuestName = await GetGuestNameById(apiRes.GuestId),
                                RoomNumber = await GetRoomNumberById(apiRes.RoomId),
                                RoomType = await GetRoomTypeById(apiRes.RoomId),
                                CheckInDate = apiRes.CheckInDate,
                                CheckOutDate = apiRes.CheckOutDate,
                                Status = apiRes.Status
                            });
                        }
                    }

                    _reservations = new BindingList<Reservation>(formReservations);

                    dgvReservations.DataSource = null;
                    dgvReservations.DataSource = _reservations;
                    dgvReservations.ClearSelection();

                    ShowStatus($"Loaded {_reservations.Count} active reservations");
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

        private async Task<string> GetRoomTypeById(int roomId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"rooms/{roomId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var room = JsonSerializer.Deserialize<ApiRoom>(json, options);
                    return room?.RoomType ?? "N/A";
                }
            }
            catch { }
            return "N/A";
        }

        private void UseDummyReservations()
        {
            _reservations = new BindingList<Reservation>
            {
                new Reservation {
                    Id = 1,
                    GuestName = "John Smith",
                    RoomNumber = "101",
                    RoomType = "Single",
                    CheckInDate = DateTime.Today,
                    CheckOutDate = DateTime.Today.AddDays(3),
                    Status = "Confirmed"
                },
                new Reservation {
                    Id = 2,
                    GuestName = "Maria Garcia",
                    RoomNumber = "201",
                    RoomType = "Double",
                    CheckInDate = DateTime.Today,
                    CheckOutDate = DateTime.Today.AddDays(2),
                    Status = "Checked-In"
                },
                new Reservation {
                    Id = 3,
                    GuestName = "David Chen",
                    RoomNumber = "301",
                    RoomType = "Suite",
                    CheckInDate = DateTime.Today.AddDays(1),
                    CheckOutDate = DateTime.Today.AddDays(4),
                    Status = "Confirmed"
                }
            };

            dgvReservations.DataSource = null;
            dgvReservations.DataSource = _reservations;
            dgvReservations.ClearSelection();

            ShowStatus("Using sample reservation data");
        }

        private async Task LoadGuestsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("guests");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var guestList = JsonSerializer.Deserialize<List<ApiGuest>>(json, options) ?? new List<ApiGuest>();

                    // Convert to form guests
                    var formGuests = new List<Guest>();
                    foreach (var apiGuest in guestList)
                    {
                        formGuests.Add(new Guest
                        {
                            Id = apiGuest.Id,
                            FirstName = apiGuest.FirstName,
                            LastName = apiGuest.LastName
                        });
                    }
                    _guests = new BindingList<Guest>(formGuests);

                    cmbGuestName.Items.Clear();
                    foreach (var guest in _guests)
                    {
                        cmbGuestName.Items.Add(guest.FullName);
                    }
                    if (cmbGuestName.Items.Count > 0)
                        cmbGuestName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading guests: {ex.Message}");
                // Add sample guests
                _guests = new BindingList<Guest>
                {
                    new Guest { Id = 1, FirstName = "John", LastName = "Smith" },
                    new Guest { Id = 2, FirstName = "Maria", LastName = "Garcia" },
                    new Guest { Id = 3, FirstName = "David", LastName = "Chen" }
                };

                cmbGuestName.Items.Clear();
                foreach (var guest in _guests)
                {
                    cmbGuestName.Items.Add(guest.FullName);
                }
                if (cmbGuestName.Items.Count > 0)
                    cmbGuestName.SelectedIndex = 0;
            }
        }

        private async Task LoadRoomsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("rooms");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var roomList = JsonSerializer.Deserialize<List<ApiRoom>>(json, options) ?? new List<ApiRoom>();

                    // Filter available rooms and convert to form rooms
                    var formRooms = new List<Room>();
                    foreach (var apiRoom in roomList)
                    {
                        if (apiRoom.Status == "Available")
                        {
                            formRooms.Add(new Room
                            {
                                Id = apiRoom.Id,
                                RoomNumber = apiRoom.RoomNumber,
                                RoomType = apiRoom.RoomType,
                                Price = apiRoom.Price,
                                Floor = apiRoom.Floor,
                                Status = apiRoom.Status
                            });
                        }
                    }
                    _rooms = new BindingList<Room>(formRooms);

                    dgvAvailableRooms.DataSource = null;
                    dgvAvailableRooms.DataSource = _rooms;
                    dgvAvailableRooms.ClearSelection();

                    UpdateAvailableRoomsCount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading rooms: {ex.Message}");
                // Add sample rooms
                _rooms = new BindingList<Room>
                {
                    new Room { Id = 1, RoomNumber = "101", RoomType = "Single", Price = 80.00m, Floor = 1, Status = "Available" },
                    new Room { Id = 2, RoomNumber = "102", RoomType = "Double", Price = 120.00m, Floor = 1, Status = "Available" },
                    new Room { Id = 3, RoomNumber = "201", RoomType = "Suite", Price = 250.00m, Floor = 2, Status = "Available" }
                };

                dgvAvailableRooms.DataSource = null;
                dgvAvailableRooms.DataSource = _rooms;
                UpdateAvailableRoomsCount();
            }
        }

        private void UpdateAvailableRoomsCount()
        {
            lblAvailableRooms.Text = $"Available Rooms: {_rooms.Count}";
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            string validationError = ValidateCheckInForm();
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if it's from reservation list or new check-in
                if (dgvReservations.SelectedRows.Count > 0)
                {
                    // Check-in from existing reservation
                    var selectedRow = dgvReservations.SelectedRows[0];
                    var reservationId = selectedRow.Cells["colResID"].Value?.ToString();

                    if (!string.IsNullOrEmpty(reservationId))
                    {
                        ShowStatus($"Checking in reservation {reservationId}...");

                        var updateData = new
                        {
                            status = "Checked-In"
                        };

                        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                        var json = JsonSerializer.Serialize(updateData, options);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await _httpClient.PutAsync($"reservations/{reservationId}", content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Guest checked in successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataAsync();
                        }
                        else
                        {
                            var error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Failed to check in: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Direct check-in without reservation
                    MessageBox.Show("Direct check-in functionality would be implemented here.\n\nThis would create a new reservation and check-in.",
                        "Direct Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateCheckInForm()
        {
            if (dgvReservations.SelectedRows.Count == 0)
                return "Please select a reservation to check-in";

            var selectedRow = dgvReservations.SelectedRows[0];
            var status = selectedRow.Cells["colStatus"].Value?.ToString();

            if (status == "Checked-In")
                return "This guest is already checked-in";

            if (status == "Checked-Out")
                return "This reservation has been checked out";

            return string.Empty;
        }

        private async void btnCheckOut_Click(object sender, EventArgs e)
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
            var status = selectedRow.Cells["colStatus"].Value?.ToString();

            if (string.IsNullOrEmpty(reservationId))
            {
                MessageBox.Show("Invalid reservation selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (status != "Checked-In")
            {
                MessageBox.Show("Only checked-in guests can be checked out", "Invalid Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Check out {guestName} from room {roomNumber}?\n\nThis will mark the reservation as completed and free up the room.",
                "Confirm Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Checking out {guestName}...");

                    var updateData = new
                    {
                        status = "Checked-Out"
                    };

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(updateData, options);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync($"reservations/{reservationId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Guest checked out successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to check out: {error}", "Error",
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
            ShowStatus("Data refreshed");
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            ClearForm();
            ShowStatus("Ready for new check-in...");
        }

        private void ClearForm()
        {
            if (cmbGuestName.Items.Count > 0)
                cmbGuestName.SelectedIndex = 0;
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            dgvReservations.ClearSelection();
            dgvAvailableRooms.ClearSelection();
        }

        private void ShowStatus(string message)
        {
            this.Text = $"Check-In/Check-Out - {message}";
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var selectedRow = dgvReservations.SelectedRows[0];
                var guestName = selectedRow.Cells["colGuestName"].Value?.ToString();
                var roomNumber = selectedRow.Cells["colRoomNumber"].Value?.ToString();
                var status = selectedRow.Cells["colStatus"].Value?.ToString();

                if (!string.IsNullOrEmpty(guestName))
                    cmbGuestName.Text = guestName;

                // Enable/disable buttons based on status
                btnCheckIn.Enabled = (status == "Confirmed");
                btnCheckOut.Enabled = (status == "Checked-In");

                ShowStatus($"Selected: {guestName} - Room {roomNumber} ({status})");
            }
            else
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
            }
        }

        private void dgvAvailableRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAvailableRooms.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAvailableRooms.SelectedRows[0];
                var roomType = selectedRow.Cells["colRoomType"].Value?.ToString();
                var roomNumber = selectedRow.Cells["colRoomNo"].Value?.ToString();

                if (!string.IsNullOrEmpty(roomType))
                    cmbRoomType.Text = roomType;

                ShowStatus($"Selected room: {roomNumber} ({roomType})");
            }
        }

        // Form model classes
        public class Reservation
        {
            public int Id { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public DateTime? ActualCheckInDate { get; set; }
            public DateTime? ActualCheckOutDate { get; set; }
            public string Status { get; set; } = "Confirmed";
        }

        public class Guest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string FullName => $"{FirstName} {LastName}";
        }

        public class Room
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Floor { get; set; }
            public string Status { get; set; } = "Available";
        }

        // API model classes for deserialization
        private class ApiReservation
        {
            public int Id { get; set; }
            public string ReservationNumber { get; set; } = string.Empty;
            public int GuestId { get; set; }
            public int RoomId { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public string Status { get; set; } = "Confirmed";
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
            public int Floor { get; set; }
            public string Status { get; set; } = "Available";
        }
    }
}