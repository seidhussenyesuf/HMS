using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GuestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            try
            {
                var guests = await _context.Guests
                    .Where(g => g.IsActive)
                    .OrderBy(g => g.Id)
                    .ToListAsync();
                return Ok(guests);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetGuests: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            try
            {
                var guest = await _context.Guests.FindAsync(id);

                if (guest == null || !guest.IsActive)
                {
                    return NotFound(new { error = $"Guest with ID {id} not found" });
                }

                return guest;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetGuest: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/guests - Add NEW guest
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest([FromBody] JsonElement guestData)
        {
            try
            {
                Console.WriteLine($"API: Received POST request for new guest");

                // Validate required fields
                if (!guestData.TryGetProperty("firstName", out JsonElement firstNameElement) ||
                    string.IsNullOrEmpty(firstNameElement.GetString()))
                {
                    return BadRequest(new { error = "First name is required" });
                }

                if (!guestData.TryGetProperty("lastName", out JsonElement lastNameElement) ||
                    string.IsNullOrEmpty(lastNameElement.GetString()))
                {
                    return BadRequest(new { error = "Last name is required" });
                }

                if (!guestData.TryGetProperty("phone", out JsonElement phoneElement) ||
                    string.IsNullOrEmpty(phoneElement.GetString()))
                {
                    return BadRequest(new { error = "Phone is required" });
                }

                if (!guestData.TryGetProperty("idNumber", out JsonElement idNumberElement) ||
                    string.IsNullOrEmpty(idNumberElement.GetString()))
                {
                    return BadRequest(new { error = "ID number is required" });
                }

                // Extract values
                var idNumber = idNumberElement.GetString() ?? string.Empty;
                var firstName = firstNameElement.GetString() ?? string.Empty;
                var lastName = lastNameElement.GetString() ?? string.Empty;
                var phone = phoneElement.GetString() ?? string.Empty;
                var email = guestData.TryGetProperty("email", out JsonElement emailElement) ?
                    emailElement.GetString() ?? string.Empty : string.Empty;
                var address = guestData.TryGetProperty("address", out JsonElement addressElement) ?
                    addressElement.GetString() ?? string.Empty : string.Empty;
                var idType = guestData.TryGetProperty("idType", out JsonElement idTypeElement) ?
                    idTypeElement.GetString() ?? "National ID" : "National ID";
                var notes = guestData.TryGetProperty("notes", out JsonElement notesElement) ?
                    notesElement.GetString() ?? string.Empty : string.Empty;

                // Check for duplicate ID number
                var existingGuest = await _context.Guests
                    .FirstOrDefaultAsync(g => g.IDNumber == idNumber && g.IsActive);

                if (existingGuest != null)
                {
                    return BadRequest(new { error = $"Guest with ID number '{idNumber}' already exists." });
                }

                // Check for duplicate email (if provided)
                if (!string.IsNullOrEmpty(email))
                {
                    var duplicateEmail = await _context.Guests
                        .FirstOrDefaultAsync(g => g.Email == email && g.IsActive);

                    if (duplicateEmail != null)
                    {
                        return BadRequest(new { error = $"Guest with email '{email}' already exists." });
                    }
                }

                var guest = new Guest
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    Address = address,
                    IDType = idType,
                    IDNumber = idNumber,
                    Notes = notes,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true
                };

                _context.Guests.Add(guest);
                await _context.SaveChangesAsync();

                Console.WriteLine($"API: Guest created with ID: {guest.Id}");
                return CreatedAtAction("GetGuest", new { id = guest.Id }, guest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PostGuest: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/guests/5 - Update EXISTING guest
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(int id, [FromBody] JsonElement guestData)
        {
            try
            {
                Console.WriteLine($"API: Received PUT request for guest ID: {id}");

                var guest = await _context.Guests.FindAsync(id);
                if (guest == null || !guest.IsActive)
                {
                    Console.WriteLine($"API: Guest with ID {id} not found");
                    return NotFound(new { error = $"Guest with ID {id} not found" });
                }

                // Update fields if they exist in JSON
                if (guestData.TryGetProperty("firstName", out JsonElement firstName))
                    guest.FirstName = firstName.GetString() ?? guest.FirstName;

                if (guestData.TryGetProperty("lastName", out JsonElement lastName))
                    guest.LastName = lastName.GetString() ?? guest.LastName;

                if (guestData.TryGetProperty("phone", out JsonElement phone))
                    guest.Phone = phone.GetString() ?? guest.Phone;

                if (guestData.TryGetProperty("email", out JsonElement email))
                {
                    var newEmail = email.GetString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(newEmail) && guest.Email != newEmail)
                    {
                        // Check for duplicate email
                        var duplicateEmail = await _context.Guests
                            .FirstOrDefaultAsync(g => g.Email == newEmail && g.Id != id && g.IsActive);

                        if (duplicateEmail != null)
                        {
                            return BadRequest(new { error = $"Another guest with email '{newEmail}' already exists." });
                        }
                        guest.Email = newEmail;
                    }
                }

                if (guestData.TryGetProperty("address", out JsonElement address))
                    guest.Address = address.GetString() ?? guest.Address;

                if (guestData.TryGetProperty("idType", out JsonElement idType))
                    guest.IDType = idType.GetString() ?? guest.IDType;

                if (guestData.TryGetProperty("idNumber", out JsonElement idNumber))
                {
                    var newIdNumber = idNumber.GetString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(newIdNumber) && guest.IDNumber != newIdNumber)
                    {
                        // Check for duplicate ID number
                        var duplicateId = await _context.Guests
                            .FirstOrDefaultAsync(g => g.IDNumber == newIdNumber && g.Id != id && g.IsActive);

                        if (duplicateId != null)
                        {
                            return BadRequest(new { error = $"Another guest with ID number '{newIdNumber}' already exists." });
                        }
                        guest.IDNumber = newIdNumber;
                    }
                }

                if (guestData.TryGetProperty("notes", out JsonElement notes))
                    guest.Notes = notes.GetString() ?? guest.Notes;

                guest.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                Console.WriteLine($"API: Guest ID {id} updated successfully");

                return Ok(new { message = "Guest updated successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PutGuest: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            try
            {
                var guest = await _context.Guests.FindAsync(id);
                if (guest == null)
                {
                    return NotFound(new { error = $"Guest with ID {id} not found" });
                }

                // Soft delete (set IsActive to false)
                guest.IsActive = false;
                guest.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Guest deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: api/guests/search?query=searchterm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Guest>>> SearchGuests([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return await GetGuests();
                }

                var guests = await _context.Guests
                    .Where(g => g.IsActive && (
                        g.FirstName.Contains(query) ||
                        g.LastName.Contains(query) ||
                        g.Phone.Contains(query) ||
                        g.Email.Contains(query) ||
                        g.IDNumber.Contains(query) ||
                        g.Address.Contains(query)
                    ))
                    .OrderBy(g => g.Id)
                    .ToListAsync();

                return Ok(guests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}