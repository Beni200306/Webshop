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
            CartItem? delete = Cart.FirstOrDefault(x => x.Id == id);
            if (delete is not null)
            {
                Cart.Remove(delete);
            }
        }
        public void Add(CartItem cartItem)
        {
            Cart.Add(cartItem);
        }
    }
}
