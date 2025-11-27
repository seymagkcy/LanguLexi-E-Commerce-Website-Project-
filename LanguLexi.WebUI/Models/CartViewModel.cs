using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.Models
{
    public class CartViewModel
    {
        public List<CartItem>? CartItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
