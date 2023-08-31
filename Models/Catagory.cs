using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Catagory
    {
        public int Id { get; set; }
      
       [Remote(action: "NameExist", controller: "NameExistVaild", ErrorMessage = "This Catagory Is Already Exist ",AdditionalFields = "Id,Description")]
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
