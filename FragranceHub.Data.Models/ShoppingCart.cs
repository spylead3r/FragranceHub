using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Data.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new List<ShoppingCartItem>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public virtual ICollection<ShoppingCartItem> CartItems { get; set; }
    }
}
