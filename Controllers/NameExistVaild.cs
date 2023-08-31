using e_commerce.Models;
using e_commerce.Servies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class NameExistVaild : Controller
    {
        private readonly ICatagoryServies catagoryServies;
        private readonly IOfferServies offerServies;
        private readonly UserManager<IdentityUser> userManager;

        public NameExistVaild(ICatagoryServies _catagoryServies, IOfferServies _offerServies, UserManager<IdentityUser> _userManager)
        {
            catagoryServies = _catagoryServies;
            offerServies = _offerServies;
            userManager = _userManager;
        }
        public async Task<IActionResult> NameExist(string Name, int Id)
        {

            Catagory catagory = await catagoryServies.getByName(Name);
            Offer offer = await offerServies.getByName(Name);
            if (Id == 0) //add
            {
                if (catagory == null || offer == null)
                {
                    return Json(true);
                }
                else
                { ///name exist in db
                    return Json(false);
                }

            }
            else //edit
            {
                if (catagory == null || offer == null)
                {
                    return Json(true);
                }
                else
                {
                    if (catagory.Id == Id || offer.Id == Id)
                        return Json(true);
                    else
                        return Json(false);
                }
            }
        }
       
    }
    }

    