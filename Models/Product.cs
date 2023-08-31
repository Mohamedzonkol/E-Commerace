using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = null;
        public byte[]? Photo { get; set; }
        [Required]
        public decimal? Price { get; set; }
        // [ForeignKey("Catagory"),Required]
        public int CatagoryId { get; set; }
        public Catagory? Catagory { get; set; }
        //[ForeignKey("Offer"),Required(ErrorMessage ="This Feild Reqer")]

        public int  OfferId { get; set; }
        public Offer? Offer { get; set; }
        public DateTime Create_at { get; set; }=DateTime.Now;      
 
            
    }
}
