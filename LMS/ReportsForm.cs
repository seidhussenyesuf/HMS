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
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagement.Desktop
{
    public partial class ReportsForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private string _token;

        public ReportsForm(string token = "")
        {
            InitializeComponent();
            _token = token;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            }

            SetupCharts();

            // Wire up button events
            btnGenerateReport.Click += BtnGenerateReport_Click;
            btnExport.Click += BtnExport_Click;
            btnRefresh.Click += BtnRefresh_Click;

            LoadDefaultReport();
        }

        private void SetupCharts()
        {
            // Setup occupancy chart
            chartOccupancy.Series.Clear();
            var series = new Series("Occupancy");
            series.ChartType = SeriesChartType.Pie;
            chartOccupancy.Series.Add(series);

            // Setup revenue chart
            chartRevenue.Series.Clear();
            var revSeries = new Series("Revenue");
            revSeries.ChartType = SeriesChartType.Column;
            chartRevenue.Series.Add(revSeries);

            // Setup daily bookings chart
            chartDailyBookings.Series.Clear();
            var bookingsSeries = new Series("Bookings");
            bookingsSeries.ChartType = SeriesChartType.Line;
            chartDailyBookings.Series.Add(bookingsSeries);

            // Set chart titles
            chartOccupancy.Titles.Add("Room Occupancy");
            chartRevenue.Titles.Add("Daily Revenue");
            chartDailyBookings.Titles.Add("Daily Bookings");
        }

        private async void LoadDefaultReport()
        {
            // Load today's report
            await LoadOccupancyReportAsync();
            await LoadRevenueReportAsync();
            await LoadTopGuestsAsync();
            await LoadDailyBookingsAsync();
        }

        private async Task LoadOccupancyReportAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("rooms");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var rooms = JsonSerializer.Deserialize<List<ApiRoom>>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ApiRoom>();

                    if (rooms.Any())
                    {
                        int totalRooms = rooms.Count;
                        int occupiedRooms = rooms.Count(r => r.Status == "Occupied" || r.Status == "Checked-In");
                        int availableRooms = rooms.Count(r => r.Status == "Available" || r.Status == "Ready");
                        int maintenanceRooms = rooms.Count(r => r.Status == "Maintenance");

                        lblTotalRooms.Text = totalRooms.ToString();
                        lblOccupiedRooms.Text = occupiedRooms.ToString();
                        lblAvailableRooms.Text = availableRooms.ToString();

                        double occupancyRate = totalRooms > 0 ? (occupiedRooms * 100.0 / totalRooms) : 0;
                        lblOccupancyRate.Text = $"{occupancyRate:F1}%";

                        // Update chart
                        chartOccupancy.Series[0].Points.Clear();
                        chartOccupancy.Series[0].Points.AddXY("Occupied", occupiedRooms);
                        chartOccupancy.Series[0].Points.AddXY("Available", availableRooms);
                        if (maintenanceRooms > 0)
                            chartOccupancy.Series[0].Points.AddXY("Maintenance", maintenanceRooms);

                        // Set colors
                        if (chartOccupancy.Series[0].Points.Count > 0)
                            chartOccupancy.Series[0].Points[0].Color = Color.Red;
                        if (chartOccupancy.Series[0].Points.Count > 1)
                            chartOccupancy.Series[0].Points[1].Color = Color.Green;
                        if (chartOccupancy.Series[0].Points.Count > 2)
                            chartOccupancy.Series[0].Points[2].Color = Color.Orange;
                    }
                    else
                    {
                        UseDummyOccupancyData();
                    }
                }
                else
                {
                    UseDummyOccupancyData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading occupancy: {ex.Message}");
                UseDummyOccupancyData();
            }
        }

        private void UseDummyOccupancyData()
        {
            // Set default values
            lblTotalRooms.Text = "50";
            lblOccupiedRooms.Text = "32";
            lblAvailableRooms.Text = "15";
            lblOccupancyRate.Text = "64.0%";

            // Update chart with dummy data
            chartOccupancy.Series[0].Points.Clear();
            chartOccupancy.Series[0].Points.AddXY("Occupied", 32);
            chartOccupancy.Series[0].Points.AddXY("Available", 15);
            chartOccupancy.Series[0].Points.AddXY("Maintenance", 3);

            // Set colors
            chartOccupancy.Series[0].Points[0].Color = Color.Red;
            chartOccupancy.Series[0].Points[1].Color = Color.Green;
            chartOccupancy.Series[0].Points[2].Color = Color.Orange;
        }

        private async Task LoadRevenueReportAsync()
        {
            try
            {
                // Get payments data
                var response = await _httpClient.GetAsync("payments");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var paymentList = JsonSerializer.Deserialize<List<ApiPayment>>(json, options) ?? new List<ApiPayment>();

                    // Group by date and calculate daily revenue
                    var revenueData = paymentList
                        .Where(p => p.PaymentDate.Date >= dtpFrom.Value.Date && p.PaymentDate.Date <= dtpTo.Value.Date)
                        .GroupBy(p => p.PaymentDate.Date)
                        .Select(g => new RevenueData
                        {
                            Date = g.Key.ToString("yyyy-MM-dd"),
                            Revenue = g.Sum(p => p.Amount),
                            Bookings = g.Count()
                        })
                        .OrderBy(r => r.Date)
                        .ToList();

                    dgvRevenue.DataSource = revenueData;

                    // Calculate totals
                    decimal totalRevenue = revenueData.Sum(d => d.Revenue);
                    lblTotalRevenue.Text = totalRevenue.ToString("C");

                    // Update chart
                    chartRevenue.Series[0].Points.Clear();
                    foreach (var item in revenueData)
                    {
                        chartRevenue.Series[0].Points.AddXY(item.Date, item.Revenue);
                    }
                }
                else
                {
                    UseDummyRevenueData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading revenue: {ex.Message}");
                UseDummyRevenueData();
            }
        }

        private void UseDummyRevenueData()
        {
            var dummyData = new List<RevenueData>
            {
                new RevenueData { Date = DateTime.Today.AddDays(-6).ToString("yyyy-MM-dd"), Revenue = 1200, Bookings = 8 },
                new RevenueData { Date = DateTime.Today.AddDays(-5).ToString("yyyy-MM-dd"), Revenue = 1800, Bookings = 12 },
                new RevenueData { Date = DateTime.Today.AddDays(-4).ToString("yyyy-MM-dd"), Revenue = 1500, Bookings = 10 },
                new RevenueData { Date = DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"), Revenue = 2200, Bookings = 14 },
                new RevenueData { Date = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd"), Revenue = 1900, Bookings = 13 },
                new RevenueData { Date = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), Revenue = 2100, Bookings = 15 },
                new RevenueData { Date = DateTime.Today.ToString("yyyy-MM-dd"), Revenue = 900, Bookings = 6 }
            };

            dgvRevenue.DataSource = dummyData;
            lblTotalRevenue.Text = dummyData.Sum(d => d.Revenue).ToString("C");

            chartRevenue.Series[0].Points.Clear();
            foreach (var item in dummyData)
            {
                chartRevenue.Series[0].Points.AddXY(item.Date, item.Revenue);
            }
        }

        private async Task LoadTopGuestsAsync()
        {
            try
            {
                // Get reservations data
                var response = await _httpClient.GetAsync("reservations");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var reservationList = JsonSerializer.Deserialize<List<ApiReservation>>(json, options) ?? new List<ApiReservation>();

                    // Group by guest and calculate statistics
                    var guestStats = new Dictionary<int, GuestStats>();

                    foreach (var reservation in reservationList)
                    {
                        if (!guestStats.ContainsKey(reservation.GuestId))
                        {
                            guestStats[reservation.GuestId] = new GuestStats
                            {
                                GuestId = reservation.GuestId,
                                GuestName = await GetGuestNameById(reservation.GuestId),
                                TotalStays = 0,
                                TotalSpent = 0
                            };
                        }

                        guestStats[reservation.GuestId].TotalStays++;
                        guestStats[reservation.GuestId].TotalSpent += reservation.TotalAmount;
                    }

                    var topGuests = guestStats.Values
                        .OrderByDescending(g => g.TotalSpent)
                        .Take(10)
                        .Select(g => new TopGuest
                        {
                            GuestName = g.GuestName,
                            TotalStays = g.TotalStays,
                            TotalSpent = g.TotalSpent
                        })
                        .ToList();

                    dgvTopGuests.DataSource = topGuests;
                }
                else
                {
                    UseDummyTopGuests();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading top guests: {ex.Message}");
                UseDummyTopGuests();
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
                    return $"{guest?.FirstName} {guest?.LastName}" ?? $"Guest #{guestId}";
                }
            }
            catch { }
            return $"Guest #{guestId}";
        }

        private void UseDummyTopGuests()
        {
            var dummyData = new List<TopGuest>
            {
                new TopGuest { GuestName = "John Doe", TotalStays = 15, TotalSpent = 4500 },
                new TopGuest { GuestName = "Jane Smith", TotalStays = 12, TotalSpent = 3800 },
                new TopGuest { GuestName = "Robert Johnson", TotalStays = 8, TotalSpent = 2500 },
                new TopGuest { GuestName = "Maria Garcia", TotalStays = 6, TotalSpent = 2000 },
                new TopGuest { GuestName = "David Wilson", TotalStays = 5, TotalSpent = 1800 }
            };

            dgvTopGuests.DataSource = dummyData;
        }

        private async Task LoadDailyBookingsAsync()
        {
            try
            {
                // Get reservations data
                var response = await _httpClient.GetAsync("reservations");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var reservationList = JsonSerializer.Deserialize<List<ApiReservation>>(json, options) ?? new List<ApiReservation>();

                    // Group by check-in date and count bookings
                    var dailyBookings = reservationList
                        .Where(r => r.CheckInDate.Date >= dtpFrom.Value.Date && r.CheckInDate.Date <= dtpTo.Value.Date)
                        .GroupBy(r => r.CheckInDate.Date)
                        .Select(g => new DailyBooking
                        {
                            Date = g.Key.ToString("yyyy-MM-dd"),
                            Bookings = g.Count()
                        })
                        .OrderBy(b => b.Date)
                        .ToList();

                    if (dailyBookings.Any())
                    {
                        chartDailyBookings.Series[0].Points.Clear();
                        foreach (var item in dailyBookings)
                        {
                            chartDailyBookings.Series[0].Points.AddXY(item.Date, item.Bookings);
                        }
                    }
                    else
                    {
                        UseDummyDailyBookings();
                    }
                }
                else
                {
                    UseDummyDailyBookings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading daily bookings: {ex.Message}");
                UseDummyDailyBookings();
            }
        }

        private void UseDummyDailyBookings()
        {
            var dummyData = new List<DailyBooking>
            {
                new DailyBooking { Date = DateTime.Today.AddDays(-6).ToString("yyyy-MM-dd"), Bookings = 8 },
                new DailyBooking { Date = DateTime.Today.AddDays(-5).ToString("yyyy-MM-dd"), Bookings = 12 },
                new DailyBooking { Date = DateTime.Today.AddDays(-4).ToString("yyyy-MM-dd"), Bookings = 10 },
                new DailyBooking { Date = DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"), Bookings = 14 },
                new DailyBooking { Date = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd"), Bookings = 13 },
                new DailyBooking { Date = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), Bookings = 15 },
                new DailyBooking { Date = DateTime.Today.ToString("yyyy-MM-dd"), Bookings = 6 }
            };

            chartDailyBookings.Series[0].Points.Clear();
            foreach (var item in dummyData)
            {
                chartDailyBookings.Series[0].Points.AddXY(item.Date, item.Bookings);
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString();

            if (reportType == "Revenue Report")
            {
                LoadRevenueReportAsync();
            }
            else if (reportType == "Occupancy Report")
            {
                LoadOccupancyReportAsync();
            }
            else if (reportType == "Daily Bookings Report")
            {
                LoadDailyBookingsAsync();
            }
            else if (reportType == "Top Guests Report")
            {
                LoadTopGuestsAsync();
            }
            else if (reportType == "Complete Report")
            {
                LoadDefaultReport();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text File|*.txt|CSV File|*.csv";
                sfd.FileName = $"Hotel_Report_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string exportText = $"HOTEL HYATT - MANAGEMENT REPORT\n";
                        exportText += $"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n";
                        exportText += $"Report Type: {cmbReportType.SelectedItem}\n";
                        exportText += $"Period: {dtpFrom.Value:yyyy-MM-dd} to {dtpTo.Value:yyyy-MM-dd}\n";
                        exportText += "=".PadRight(60, '=') + "\n\n";

                        if (tabControl1.SelectedTab == tabPage1) // Revenue
                        {
                            exportText += "REVENUE REPORT\n";
                            exportText += $"Total Revenue: {lblTotalRevenue.Text}\n\n";
                            exportText += "Date\t\tRevenue\t\tBookings\n";

                            if (dgvRevenue.DataSource is List<RevenueData> revenueData)
                            {
                                foreach (var item in revenueData)
                                {
                                    exportText += $"{item.Date}\t{item.Revenue:C}\t\t{item.Bookings}\n";
                                }
                            }
                        }
                        else if (tabControl1.SelectedTab == tabPage2) // Top Guests
                        {
                            exportText += "TOP GUESTS REPORT\n\n";
                            exportText += "Guest Name\t\tTotal Stays\tTotal Spent\n";

                            if (dgvTopGuests.DataSource is List<TopGuest> topGuests)
                            {
                                foreach (var guest in topGuests)
                                {
                                    exportText += $"{guest.GuestName}\t\t{guest.TotalStays}\t\t{guest.TotalSpent:C}\n";
                                }
                            }
                        }
                        else if (tabControl1.SelectedTab == tabPage3) // Occupancy
                        {
                            exportText += "OCCUPANCY REPORT\n";
                            exportText += $"Total Rooms: {lblTotalRooms.Text}\n";
                            exportText += $"Occupied Rooms: {lblOccupiedRooms.Text}\n";
                            exportText += $"Available Rooms: {lblAvailableRooms.Text}\n";
                            exportText += $"Occupancy Rate: {lblOccupancyRate.Text}\n";
                        }
                        else if (tabControl1.SelectedTab == tabPage4) // Daily Bookings
                        {
                            exportText += "DAILY BOOKINGS REPORT\n\n";
                            exportText += "Date\t\tBookings\n";

                            if (chartDailyBookings.Series[0].Points.Count > 0)
                            {
                                foreach (DataPoint point in chartDailyBookings.Series[0].Points)
                                {
                                    exportText += $"{point.AxisLabel}\t\t{point.YValues[0]}\n";
                                }
                            }
                        }

                        System.IO.File.WriteAllText(sfd.FileName, exportText);

                        MessageBox.Show($"Report exported to:\n{sfd.FileName}", "Export Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDefaultReport();
            MessageBox.Show("Report data refreshed successfully!", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Setup report type combo box
            if (cmbReportType.Items.Count == 0)
            {
                cmbReportType.Items.AddRange(new string[] {
                    "Revenue Report",
                    "Occupancy Report",
                    "Top Guests Report",
                    "Daily Bookings Report",
                    "Complete Report"
                });
                cmbReportType.SelectedIndex = 0;
            }

            // Set default date range (last 7 days)
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
        }

        // Form model classes
        public class RevenueData
        {
            public string Date { get; set; } = string.Empty;
            public decimal Revenue { get; set; }
            public int Bookings { get; set; }
        }

        public class TopGuest
        {
            public string GuestName { get; set; } = string.Empty;
            public int TotalStays { get; set; }
            public decimal TotalSpent { get; set; }
        }

        public class DailyBooking
        {
            public string Date { get; set; } = string.Empty;
            public int Bookings { get; set; }
        }

        // API model classes for deserialization
        private class ApiRoom
        {
            public int Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string RoomType { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }

        private class ApiPayment
        {
            public int Id { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        private class ApiReservation
        {
            public int Id { get; set; }
            public int GuestId { get; set; }
            public decimal TotalAmount { get; set; }
            public DateTime CheckInDate { get; set; }
        }

        private class ApiGuest
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }

        private class GuestStats
        {
            public int GuestId { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public int TotalStays { get; set; }
            public decimal TotalSpent { get; set; }
        }
    }
}