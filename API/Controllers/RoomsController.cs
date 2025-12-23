using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // POST: api/rooms - Add NEW room
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom([FromBody] JsonElement roomData)
        {
            try
            {
                Console.WriteLine($"API: Received POST request for new room");

                var room = new Room
                {
                    RoomNumber = roomData.GetProperty("roomNumber").GetString() ?? string.Empty,
                    RoomType = roomData.GetProperty("roomType").GetString() ?? "Standard",
                    Floor = roomData.GetProperty("floor").GetInt32(),
                    Status = roomData.GetProperty("status").GetString() ?? "Available",
                    Price = roomData.GetProperty("price").GetDecimal(),
                    IsAvailable = true,
                    IsActive = true
                };

                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();

                Console.WriteLine($"API: Room created with ID: {room.Id}");
                return CreatedAtAction("GetRoom", new { id = room.Id }, room);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PostRoom: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/rooms/5 - Update EXISTING room
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, [FromBody] JsonElement roomData)
        {
            try
            {
                Console.WriteLine($"API: Received PUT request for room ID: {id}");

                var room = await _context.Rooms.FindAsync(id);
                if (room == null)
                {
                    Console.WriteLine($"API: Room with ID {id} not found");
                    return NotFound(new { error = $"Room with ID {id} not found" });
                }

                // Update only if property exists in JSON
                if (roomData.TryGetProperty("roomNumber", out JsonElement roomNumber))
                    room.RoomNumber = roomNumber.GetString() ?? room.RoomNumber;

                if (roomData.TryGetProperty("roomType", out JsonElement roomType))
                    room.RoomType = roomType.GetString() ?? room.RoomType;

                if (roomData.TryGetProperty("floor", out JsonElement floor))
                    room.Floor = floor.GetInt32();

                if (roomData.TryGetProperty("status", out JsonElement status))
                {
                    room.Status = status.GetString() ?? room.Status;
                    room.IsAvailable = room.Status == "Available";
                }

                if (roomData.TryGetProperty("price", out JsonElement price))
                    room.Price = price.GetDecimal();

                await _context.SaveChangesAsync();
                Console.WriteLine($"API: Room ID {id} updated successfully");

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PutRoom: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null)
                {
                    return NotFound(new { error = $"Room with ID {id} not found" });
                }

                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/rooms/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateRoomStatus(int id, [FromQuery] string status)
        {
            try
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null)
                {
                    return NotFound(new { error = $"Room with ID {id} not found" });
                }

                room.Status = status;
                room.IsAvailable = status == "Available";
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}