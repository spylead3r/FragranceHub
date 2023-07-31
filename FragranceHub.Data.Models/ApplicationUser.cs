using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FragranceHub.Common.EntityValidationConstants.User;

namespace FragranceHub.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.OwnedFragrances = new List<Fragrance>();
            this.PostedReviews = new HashSet<Review>();
            this.ShoppingCartItems = new List<ShoppingCartItem>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }
        public virtual ICollection<Fragrance> OwnedFragrances { get; set; }

        public virtual ICollection<Review> PostedReviews { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }


    }

}
