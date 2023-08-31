using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_commerce.Configrution;
using e_commerce.Models;
using e_commerce.Servies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace e_commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartServies cartServies;
        private readonly UserManager<IdentityUser> userManager;

        public CartController(ICartServies _cartServies, UserManager<IdentityUser> _userManager)
        {
            cartServies = _cartServies;
            userManager = _userManager;
        }


        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);

            return View(cartServies.GetAll(userId));
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Cart cart = await cartServies.GetCartById(id);
                if (cart is null)
                    return NotFound("Please Try Again");
                else
                {
                    await cartServies.Delete(cart);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", "Somting Is Wrong");
                return RedirectToAction("Index");

            }

        }
        public async Task<IActionResult> Edit(int CardId, int Quantity)
        {
            Cart cart = await cartServies.GetCartById(CardId);
            cart.Quantity = +Quantity;
            await cartServies.Update(cart);
            return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> addToCard(int productId, int Quantity)
        {
            try
            {
                var UserId = userManager.GetUserId(User);
                Cart existCart = await cartServies.GetUserCart(productId, UserId);
                if (existCart is null)
                {
                    Cart cart = new Cart
                    {
                        ProductId = productId,
                        Quantity = Quantity,
                        UserID = UserId
                    };
                    await cartServies.Create(cart);
                }
                else
                {
                    existCart.Quantity += Quantity;
                    await cartServies.Update(existCart);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", "Sometjing Is Wrong");
                return RedirectToAction("Index");
            }
        }
     
    }
}