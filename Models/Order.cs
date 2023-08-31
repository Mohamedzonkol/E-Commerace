using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProuductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Deteils")]
        public int OrderDetailsId { get; set; }
        public OrderDeteils? Deteils { get; set; }


    }
}
