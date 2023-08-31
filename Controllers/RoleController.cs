using e_commerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Win32;
using System.Data;
using System.Security.Principal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_commerce.Controllers
{
    [Authorize(Roles = ("Admin"))]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RoleController(RoleManager<IdentityRole> _roleManager,UserManager<IdentityUser> _userManager,SignInManager<IdentityUser>_signInManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] RoleViewModel newRole)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole { Name = newRole.RoleName };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    return BadRequest("Somting Is wrong");


                }
            }
            else 
            {
                return BadRequest("Somting Is wrong");
            }
        }
        public IActionResult addAdminToRole()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task <IActionResult> addAdminToRole([FromForm]RegsisterAdminViewModel newAdim)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser {UserName=newAdim.Name,Email=newAdim.Email };
              IdentityResult result= await userManager.CreateAsync (user,newAdim.Password);
                if (result.Succeeded)
                {
                    //add Admin Role
                    await userManager.AddToRoleAsync(user, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(user, false);
                    //congirm email
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                     await userManager.ConfirmEmailAsync(user, code);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError("", error.Description);
                    }
                }
                }
                return View(newAdim);
            }
        public IActionResult Index()
        {
            return View();
        }
    }
}
