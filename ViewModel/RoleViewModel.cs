using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModel
{
    public class RoleViewModel
    {
        [Required,Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
