using System.ComponentModel.DataAnnotations;


namespace PetPals.Data.Models
{
    using static PetPals.Common.EntityValidationConstants.Feedback;

    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Comment { get; set; } = null!;


        [Required]
        [Range(RatingMinValue,RatingMaxValue)]
        public int Rating { get; set; } 

        [Required]
        public DateTime Date { get; set; }
    }
}
