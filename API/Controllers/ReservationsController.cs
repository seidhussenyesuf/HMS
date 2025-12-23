using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetReservations()
        {
            try
            {
                var reservations = await _context.Reservations
                    .Include(r => r.Guest)
                    .Include(r => r.Room)
                    .OrderByDescending(r => r.CreatedDate)
                    .Select(r => new
                    {
                        r.Id,
                        r.ReservationNumber,
                        GuestId = r.Guest.Id,
                        GuestFirstName = r.Guest.FirstName,
                        GuestLastName = r.Guest.LastName,
                        RoomId = r.Room.Id,
                        RoomNumber = r.Room.RoomNumber,
                        r.CheckInDate,
                        r.CheckOutDate,
                        r.NumberOfAdults,
                        r.NumberOfChildren,
                        r.TotalAmount,
                        r.Status,
                        r.SpecialRequests,
                        r.CreatedDate
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/reservations/search?query=searchterm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<object>>> SearchReservations([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return await GetReservations();
                }

                var reservations = await _context.Reservations
                    .Include(r => r.Guest)
                    .Include(r => r.Room)
                    .Where(r =>
                        r.ReservationNumber.Contains(query) ||
                        r.Guest.FirstName.Contains(query) ||
                        r.Guest.LastName.Contains(query) ||
                        r.Guest.Phone.Contains(query) ||
                        r.Guest.Email.Contains(query) ||
                        r.Room.RoomNumber.Contains(query) ||
                        r.Status.Contains(query))
                    .OrderByDescending(r => r.CreatedDate)
                    .Select(r => new
                    {
                        r.Id,
                        r.ReservationNumber,
                        GuestId = r.Guest.Id,
                        GuestFirstName = r.Guest.FirstName,
                        GuestLastName = r.Guest.LastName,
                        RoomId = r.Room.Id,
                        RoomNumber = r.Room.RoomNumber,
                        r.CheckInDate,
                        r.CheckOutDate,
                        r.NumberOfAdults,
                        r.NumberOfChildren,
                        r.TotalAmount,
                        r.Status,
                        r.SpecialRequests,
                        r.CreatedDate
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/reservations/available-rooms?checkIn=2023-12-01&checkOut=2023-12-02&roomType=Standard
        [HttpGet("available-rooms")]
        public async Task<ActionResult<IEnumerable<object>>> GetAvailableRooms(
            [FromQuery] DateTime checkIn,
            [FromQuery] DateTime checkOut,
            [FromQuery] string? roomType = null)
        {
            try
            {
                if (checkOut <= checkIn)
                {
                    return BadRequest(new { error = "Check-out date must be after check-in date" });
                }

                // Find rooms that are not reserved for the given dates
                var reservedRoomIds = await _context.Reservations
                    .Where(r => r.Status != "Cancelled" &&
                           !(r.CheckOutDate <= checkIn || r.CheckInDate >= checkOut))
                    .Select(r => r.RoomId)
                    .Distinct()
                    .ToListAsync();

                var availableRooms = await _context.Rooms
                    .Where(r =>
                        r.Status == "Available" &&
                        r.IsActive &&
                        !reservedRoomIds.Contains(r.Id) &&
                        (string.IsNullOrEmpty(roomType) || r.RoomType == roomType))
                    .Select(r => new
                    {
                        r.Id,
                        r.RoomNumber,
                        r.RoomType,
                        r.Floor,
                        r.Price,
                        r.Status
                    })
                    .ToListAsync();

                return Ok(availableRooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] JsonElement reservationData)
        {
            try
            {
                Console.WriteLine($"API: Creating new reservation");

                // Generate reservation number
                var reservationNumber = $"RES-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";

                // Parse request data
                var guestId = reservationData.GetProperty("guestId").GetInt32();
                var roomId = reservationData.GetProperty("roomId").GetInt32();
                var checkIn = reservationData.GetProperty("checkInDate").GetDateTime();
                var checkOut = reservationData.GetProperty("checkOutDate").GetDateTime();
                var numberOfAdults = reservationData.GetProperty("numberOfAdults").GetInt32();
                var numberOfChildren = reservationData.GetProperty("numberOfChildren").GetInt32();
                var totalAmount = reservationData.GetProperty("totalAmount").GetDecimal();
                var specialRequests = reservationData.GetProperty("specialRequests").GetString();

                // Validate dates
                if (checkOut <= checkIn)
                {
                    return BadRequest(new { error = "Check-out date must be after check-in date" });
                }

                // Check if room is available
                var isRoomAvailable = await _context.Reservations
                    .Where(r => r.RoomId == roomId && r.Status != "Cancelled" &&
                           !(r.CheckOutDate <= checkIn || r.CheckInDate >= checkOut))
                    .CountAsync() == 0;

                if (!isRoomAvailable)
                {
                    return BadRequest(new { error = "Selected room is not available for the chosen dates" });
                }

                // Get guest
                var guest = await _context.Guests.FindAsync(guestId);
                if (guest == null)
                {
                    return BadRequest(new { error = "Guest not found" });
                }

                // Get room
                var room = await _context.Rooms.FindAsync(roomId);
                if (room == null)
                {
                    return BadRequest(new { error = "Room not found" });
                }

                // Create reservation
                var reservation = new Reservation
                {
                    ReservationNumber = reservationNumber,
                    GuestId = guestId,
                    RoomId = roomId,
                    CheckInDate = checkIn,
                    CheckOutDate = checkOut,
                    NumberOfAdults = numberOfAdults,
                    NumberOfChildren = numberOfChildren,
                    TotalAmount = totalAmount,
                    SpecialRequests = specialRequests,
                    Status = "Confirmed",
                    CreatedDate = DateTime.UtcNow
                };

                // Update room status
                room.Status = "Reserved";
                _context.Rooms.Update(room);

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();

                Console.WriteLine($"API: Reservation created with number: {reservationNumber}");

                return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, new
                {
                    reservation.Id,
                    reservation.ReservationNumber,
                    GuestId = reservation.GuestId,
                    GuestFirstName = guest.FirstName,
                    GuestLastName = guest.LastName,
                    RoomId = reservation.RoomId,
                    RoomNumber = room.RoomNumber,
                    reservation.CheckInDate,
                    reservation.CheckOutDate,
                    reservation.NumberOfAdults,
                    reservation.NumberOfChildren,
                    reservation.TotalAmount,
                    reservation.Status,
                    reservation.SpecialRequests,
                    reservation.CreatedDate
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in CreateReservation: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }


        // Add to your existing ReservationsController class

        // GET: api/reservations/checkedin
        [HttpGet("checkedin")]
        public async Task<ActionResult<IEnumerable<object>>> GetCheckedInReservations()
        {
            try
            {
                var reservations = await _context.Reservations
                    .Include(r => r.Guest)
                    .Include(r => r.Room)
                    .Where(r => r.Status == "Checked-In" || r.Status == "CheckedIn")
                    .OrderByDescending(r => r.CreatedDate)
                    .Select(r => new
                    {
                        r.Id,
                        r.ReservationNumber,
                        GuestName = r.Guest.FirstName + " " + r.Guest.LastName,
                        RoomNumber = r.Room.RoomNumber,
                        r.CheckInDate,
                        r.CheckOutDate,
                        r.TotalAmount,
                        r.Status
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/reservations/{id}/calculate-bill
        [HttpGet("{id}/calculate-bill")]
        public async Task<ActionResult<object>> CalculateBill(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reservation == null)
                {
                    return NotFound(new { error = $"Reservation with ID {id} not found" });
                }

                // Calculate the actual stay duration
                var checkIn = reservation.CheckInDate;
                var checkOut = reservation.CheckOutDate;
                var nights = (checkOut - checkIn).TotalDays;

                if (nights < 1) nights = 1; // Minimum 1 night

                // Calculate room charges (price per night * nights)
                var roomCharges = reservation.Room.Price * (decimal)nights;

                // For now, set extra charges to 0 (you can add logic for extras like minibar, laundry, etc.)
                var extraCharges = 0m;

                // Calculate tax (assuming 10%)
                var taxRate = 0.10m;
                var totalAmount = roomCharges + extraCharges;
                var tax = totalAmount * taxRate;
                var grandTotal = totalAmount + tax;

                return Ok(new
                {
                    ReservationId = reservation.Id,
                    RoomCharges = roomCharges,
                    ExtraCharges = extraCharges,
                    TotalAmount = totalAmount,
                    Tax = tax,
                    GrandTotal = grandTotal,
                    Nights = (int)nights,
                    RoomPricePerNight = reservation.Room.Price,
                    TaxRate = taxRate * 100 // 10%
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/reservations/{id}/checkout
        [HttpPost("{id}/checkout")]
        public async Task<IActionResult> CheckOutReservation(int id, [FromBody] JsonElement checkoutData)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Room)
                    .Include(r => r.Guest)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reservation == null)
                {
                    return NotFound(new { error = $"Reservation with ID {id} not found" });
                }

                // Parse checkout data
                decimal amountPaid = 0;
                string paymentMethod = "";
                string notes = "";

                if (checkoutData.TryGetProperty("amountPaid", out var amountPaidElement))
                    amountPaid = amountPaidElement.GetDecimal();

                if (checkoutData.TryGetProperty("paymentMethod", out var paymentMethodElement))
                    paymentMethod = paymentMethodElement.GetString();

                if (checkoutData.TryGetProperty("notes", out var notesElement))
                    notes = notesElement.GetString();

                // Calculate final bill
                var checkIn = reservation.CheckInDate;
                var checkOut = DateTime.Now; // Actual check-out time
                var nights = (checkOut - checkIn).TotalDays;
                if (nights < 1) nights = 1;

                var roomCharges = reservation.Room.Price * (decimal)nights;
                var extraCharges = 0m; // You can add logic for extras
                var totalAmount = roomCharges + extraCharges;
                var tax = totalAmount * 0.10m;
                var grandTotal = totalAmount + tax;

                // Update reservation
                reservation.Status = "Checked-Out";
                reservation.UpdatedDate = DateTime.UtcNow;
                reservation.CheckOutDate = checkOut; // Update to actual check-out time

                // Update room status
                reservation.Room.Status = "Available";

                // Save payment record (you might want to create a Payments table)
                // For now, we'll just update the reservation

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Check-out processed successfully",
                    ReservationNumber = reservation.ReservationNumber,
                    GuestName = reservation.Guest.FirstName + " " + reservation.Guest.LastName,
                    RoomNumber = reservation.Room.RoomNumber,
                    CheckInDate = reservation.CheckInDate,
                    CheckOutDate = checkOut,
                    TotalNights = (int)nights,
                    RoomCharges = roomCharges,
                    ExtraCharges = extraCharges,
                    Tax = tax,
                    GrandTotal = grandTotal,
                    AmountPaid = amountPaid,
                    Change = amountPaid - grandTotal,
                    PaymentMethod = paymentMethod,
                    Notes = notes
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



        // GET: api/reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return new
            {
                reservation.Id,
                reservation.ReservationNumber,
                GuestId = reservation.GuestId,
                GuestFirstName = reservation.Guest.FirstName,
                GuestLastName = reservation.Guest.LastName,
                RoomId = reservation.RoomId,
                RoomNumber = reservation.Room.RoomNumber,
                reservation.CheckInDate,
                reservation.CheckOutDate,
                reservation.NumberOfAdults,
                reservation.NumberOfChildren,
                reservation.TotalAmount,
                reservation.Status,
                reservation.SpecialRequests,
                reservation.CreatedDate
            };
        }

        // PUT: api/reservations/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateReservationStatus(int id, [FromQuery] string status)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reservation == null)
                {
                    return NotFound(new { error = $"Reservation with ID {id} not found" });
                }

                reservation.Status = status;
                reservation.UpdatedDate = DateTime.UtcNow;

                // Update room status based on reservation status
                if (status == "Checked-In")
                {
                    reservation.Room.Status = "Occupied";
                }
                else if (status == "Checked-Out" || status == "Cancelled")
                {
                    reservation.Room.Status = "Available";
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reservation == null)
                {
                    return NotFound(new { error = $"Reservation with ID {id} not found" });
                }

                // Update room status back to available
                reservation.Room.Status = "Available";

                // Remove reservation
                _context.Reservations.Remove(reservation);
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