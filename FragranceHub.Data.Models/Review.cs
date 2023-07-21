using System.ComponentModel.DataAnnotations;

using FragranceHub.Common;

namespace FragranceHub.Data.Models
{
    using static EntityValidationConstants.Review;

    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public Guid FragranceId { get; set; }
        public virtual Fragrance Fragrance { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(RatingMinValue,RatingMaxValue)]
        public int Rating { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }
    }
}
