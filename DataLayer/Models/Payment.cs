using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        // Navigation property - MUST ADD THIS
        [ForeignKey("ReservationId")]
        public virtual Reservation Reservation { get; set; } = null!;
    }
}