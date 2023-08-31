using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }
        public Product? product { get; set; }
        public int Quantity { get; set; }
        public string? UserID { get; set; }
        public IdentityUser? UserName { get; set; }
    }
}
