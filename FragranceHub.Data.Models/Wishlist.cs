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
        public ApplicationUser? User { get; set; }

        public ICollection<Fragrance> Fragrances { get; set; }
    }
}
