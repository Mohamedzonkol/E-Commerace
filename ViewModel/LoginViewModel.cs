using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { set; get; }
        [Required,DataType(DataType.Password)]
        public string Password { set; get; }
        public bool RememberMe { get; set; }
    }
}
