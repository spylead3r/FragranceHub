using System.ComponentModel.DataAnnotations;
using PetPals.Common;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.Donation;
    public class Donation
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [Range((double)MinAmount, (double)MaxAmount)]
        public decimal Amount { get; set; }


        [Required]
        public DateTime DonationDate { get; set; }

        public Guid? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public string Message { get; set; } = null!;
    }
}
