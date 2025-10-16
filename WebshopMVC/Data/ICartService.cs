using WebshopMVC.Models;

namespace WebshopMVC.Data
{
    public interface ICartService
    {
        void Add(CartItem cartItem);
        void Delete(int id);
        IEnumerable<CartItem> Read();
        CartItem ReadById(int id);
    }
}