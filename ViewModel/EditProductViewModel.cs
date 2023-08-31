using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace e_commerce.ViewModel
{
    public class EditProductViewModel
    {
        [Required,MaxLength(50)]

        public string Name { get; set; }
        public string Description { get; set; } 
       // [Required,RegularExpression(@"\.(jpg|jpeg|png|gif)$", ErrorMessage = "Plese Enter a Valid Image")]
        public IFormFile Photo { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CatagortId { get; set; }
        public int OfferId { get; set; }


    }
}
