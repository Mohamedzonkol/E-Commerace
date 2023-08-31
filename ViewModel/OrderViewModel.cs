using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModel
{
    public class OrderViewModel
    {
        [Required,MaxLength(256)]
        public String Name { get; set; }
        [Required, MaxLength(400)]
        public String Address { get; set; }
        [Required, MaxLength(12)]
        public string Phone{ get; set; }
        [Display(Name ="Total Amount")]
        public int TotalAmount { get; set; }
    }
}
