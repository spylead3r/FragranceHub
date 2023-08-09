using System.ComponentModel.DataAnnotations;

namespace FragranceHub.Data.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            this.Fragrances = new List<Fragrance>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public ICollection<Fragrance> Fragrances { get; set; }
    }
}
