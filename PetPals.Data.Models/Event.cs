using System.ComponentModel.DataAnnotations;
using PetPals.Common;

namespace PetPals.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.Event.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.Event.LocationMaxLength)]
        public string Location { get; set; }

        public int MaxParticipants { get; set; } 
    }
}
