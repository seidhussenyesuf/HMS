using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/roomtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
            try
            {
                var roomTypes = await _context.RoomTypes.ToListAsync();
                return Ok(roomTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/roomtypes
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType([FromBody] JsonElement roomTypeData)
        {
            try
            {
                var roomType = new RoomType
                {
                    TypeName = roomTypeData.GetProperty("typeName").GetString() ?? string.Empty,
                    Description = roomTypeData.GetProperty("description").GetString() ?? string.Empty,
                    Capacity = roomTypeData.GetProperty("capacity").GetInt32(),
                    BasePrice = roomTypeData.GetProperty("basePrice").GetDecimal(),
                    Amenities = roomTypeData.GetProperty("amenities").GetString() ?? string.Empty
                };

                _context.RoomTypes.Add(roomType);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRoomTypes", new { id = roomType.Id }, roomType);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/roomtypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}