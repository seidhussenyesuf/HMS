// API/Controllers/AdminController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/admin/backup
        [HttpPost("backup")]
        public async Task<IActionResult> BackupDatabase()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var backupPath = Path.Combine(Directory.GetCurrentDirectory(), "Backups");

                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }

                var backupFile = Path.Combine(backupPath, $"HotelBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var query = $"BACKUP DATABASE [{connection.Database}] TO DISK = '{backupFile}'";

                    using (var command = new SqlCommand(query, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok(new
                {
                    message = "Backup created successfully",
                    filePath = backupFile,
                    fileSize = new FileInfo(backupFile).Length
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/admin/stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var totalRooms = await _context.Rooms.CountAsync();
                var occupiedRooms = await _context.Rooms.CountAsync(r => r.Status == "Occupied");
                var availableRooms = await _context.Rooms.CountAsync(r => r.Status == "Available");
                var totalGuests = await _context.Guests.CountAsync(g => g.IsActive);
                var activeReservations = await _context.Reservations.CountAsync(r => r.IsActive && r.Status == "CheckedIn");

                return Ok(new
                {
                    TotalRooms = totalRooms,
                    OccupiedRooms = occupiedRooms,
                    AvailableRooms = availableRooms,
                    TotalGuests = totalGuests,
                    ActiveReservations = activeReservations,
                    OccupancyRate = totalRooms > 0 ? (occupiedRooms * 100.0 / totalRooms) : 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}