namespace FragranceHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static FragranceHub.Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            Fragrances = new HashSet<Fragrance>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Fragrance> Fragrances { get; set; }
    }
}
