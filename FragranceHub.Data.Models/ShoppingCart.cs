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
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
