using System.ComponentModel.DataAnnotations;


namespace FragranceHub.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid FragranceId { get; set; }
        public virtual Fragrance? Fragrance { get; set; }

        public Guid CartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
