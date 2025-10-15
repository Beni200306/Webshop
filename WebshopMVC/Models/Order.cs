using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopMVC.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName{ get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
    }
}
