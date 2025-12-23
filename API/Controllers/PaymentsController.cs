using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetPayments()
        {
            try
            {
                var payments = await _context.Payments
                    .Include(p => p.Reservation)
                    .ThenInclude(r => r.Guest)
                    .OrderByDescending(p => p.PaymentDate)
                    .ToListAsync();

                var result = payments.Select(p => new
                {
                    Id = p.Id,
                    FirstName = p.Reservation?.Guest?.FirstName ?? "Unknown",
                    LastName = p.Reservation?.Guest?.LastName ?? "Guest",
                    Amount = p.Amount,
                    PaymentMethod = p.PaymentMethod,
                    PaymentDate = p.PaymentDate,
                    Description = p.Description
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment([FromBody] JsonElement paymentData)
        {
            try
            {
                if (!paymentData.TryGetProperty("guestId", out JsonElement guestIdElement) ||
                    !paymentData.TryGetProperty("amount", out JsonElement amountElement))
                {
                    return BadRequest(new { error = "GuestId and Amount are required" });
                }

                var guestId = guestIdElement.GetInt32();
                var amount = amountElement.GetDecimal();
                var paymentMethod = paymentData.GetProperty("paymentMethod").GetString() ?? "Cash";
                var description = paymentData.TryGetProperty("description", out var desc) ? desc.GetString() : "";

                // Find reservation for this guest
                var reservation = await _context.Reservations
                    .FirstOrDefaultAsync(r => r.GuestId == guestId && (r.Status == "Checked-In" || r.Status == "Confirmed"));

                if (reservation == null)
                {
                    return BadRequest(new { error = "No active reservation found for this guest" });
                }

                var payment = new Payment
                {
                    ReservationId = reservation.Id,
                    Amount = amount,
                    PaymentMethod = paymentMethod,
                    Description = description,
                    PaymentDate = DateTime.UtcNow
                };

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPayments), new { id = payment.Id }, new
                {
                    payment.Id,
                    FirstName = reservation.Guest?.FirstName ?? "Unknown",
                    LastName = reservation.Guest?.LastName ?? "Guest",
                    payment.Amount,
                    payment.PaymentMethod,
                    payment.PaymentDate,
                    payment.Description
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                var payment = await _context.Payments.FindAsync(id);
                if (payment == null)
                {
                    return NotFound(new { error = $"Payment with ID {id} not found" });
                }

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: api/payments/search?query=searchterm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<object>>> SearchPayments([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return await GetPayments();
                }

                var payments = await _context.Payments
                    .Include(p => p.Reservation)
                    .ThenInclude(r => r.Guest)
                    .Where(p =>
                        p.Reservation.Guest.FirstName.Contains(query) ||
                        p.Reservation.Guest.LastName.Contains(query) ||
                        p.PaymentMethod.Contains(query) ||
                        p.Description.Contains(query))
                    .OrderByDescending(p => p.PaymentDate)
                    .ToListAsync();

                var result = payments.Select(p => new
                {
                    Id = p.Id,
                    FirstName = p.Reservation.Guest.FirstName,
                    LastName = p.Reservation.Guest.LastName,
                    Amount = p.Amount,
                    PaymentMethod = p.PaymentMethod,
                    PaymentDate = p.PaymentDate,
                    Description = p.Description
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}