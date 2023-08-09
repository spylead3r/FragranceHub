
using System.ComponentModel.DataAnnotations;

namespace FragranceHub.Web.ViewModels.Cart;
using static FragranceHub.Common.EntityValidationConstants.CartValidations;

public class CartFormViewModel
{
    public CartFormViewModel()
    {
        Items = new HashSet<CartItemViewModel>();
        TotalPrice = 0;
    }
    public string Id { get; set; } = null!;

    [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
    public decimal TotalPrice { get; set; }

    public IEnumerable<CartItemViewModel> Items { get; set; }

}
