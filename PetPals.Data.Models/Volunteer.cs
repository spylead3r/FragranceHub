using PetPals.Common;
using System.ComponentModel.DataAnnotations;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.Volunteer;
    public class Volunteer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string ContactInfo { get; set; } 

        public string Task { get; set; } 
    }
}
