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
            //todo:fix
        }
        public void Add(CartItem cartItem)
        {
            Cart.Add(cartItem);
            
        }
    }
}
