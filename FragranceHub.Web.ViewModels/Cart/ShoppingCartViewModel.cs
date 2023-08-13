using FragranceHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Web.ViewModels.Cart
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
