using FragranceHub.Common;

namespace FragranceHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static EntityValidationConstants.Fragrance;

    public class Fragrance
    {
        public Fragrance()
        {
            this.Reviews = new HashSet<Review>();
            this.FragrancesAccords = new HashSet<FragranceAccords>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FragranceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime PublishedOnDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public Guid? UserId { get; set; }
        
        public virtual ApplicationUser? User { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<FragranceAccords> FragrancesAccords { get; set; }
    }
}
