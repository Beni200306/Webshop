using WebshopMVC.Models;

namespace WebshopMVC.Data
{
    public class CartService : ICartService
    {
        List<CartItem> Cart;

        public CartService()
        {
            Cart = new List<CartItem>();
        }
        public IEnumerable<CartItem> Read()
        {
            return Cart;
        }
        public void Delete(int id)
        {
            CartItem? del = Cart.FirstOrDefault(x => x.ProductId == id);
            if (del is not null)
            {
                Cart.Remove(del);
            }
        }
        public void Add(CartItem cartItem)
        {
            Cart.Add(cartItem);
            
        }
    }
}
