using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Offer
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        public int OfferPersent { get; set; }
        public bool Available { get; set; }=true;
        public DateTime CreateAt { get; set; }=DateTime.Now;
       

    }
}
