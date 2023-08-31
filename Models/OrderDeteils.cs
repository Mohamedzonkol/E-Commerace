using Microsoft.AspNetCore.Identity;

namespace e_commerce.Models
{
    public class OrderDeteils
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string Phone { get; set; }
        public string UserID { get; set; }
        public IdentityUser? UserName { get; set; }     
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
