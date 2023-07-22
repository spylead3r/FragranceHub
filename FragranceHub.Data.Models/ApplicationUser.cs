using Microsoft.AspNetCore.Identity;

namespace FragranceHub.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.OwnedFragrances = new List<Fragrance>();
            this.PostedReviews = new HashSet<Review>();
            this.ShoppingCartItems = new List<ShoppingCartItem>();
        }


        public virtual ICollection<Fragrance> OwnedFragrances { get; set; }

        public virtual ICollection<Review> PostedReviews { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }


    }

}
