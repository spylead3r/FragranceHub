using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetPals.Common;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.AdoptionRequest;
    public class AdoptionRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid? PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        public virtual Pet? Pet { get; set; }

        public Guid? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        [MaxLength(StatusMaxLength)]
        public string Status { get; set; } 
    }
}
