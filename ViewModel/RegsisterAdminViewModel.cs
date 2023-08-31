using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModel
{
    public class RegsisterAdminViewModel
    {
        [Required,Display(Name="Admin Name")]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare("Password",ErrorMessage ="Password and Confirm Is Not Matched")]
        public string ConfirmPassowrd { get; set; }
    }
}
