using e_commerce.Models;
using e_commerce.Servies;
using e_commerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = ("Admin"))]
    public class OfferController : Controller

    {
        private readonly IOfferServies offerServies;

        public OfferController(IOfferServies _offerServies)
        {
            offerServies = _offerServies;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Offer newoffer) 
        {
            try
            {
                if (ModelState.IsValid == true) 
                {
                    await offerServies.Create(newoffer);
                    return RedirectToAction("List");
                }
                else
                    return BadRequest("Please Check And Try Again");
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception",ex.InnerException.Message);
                return RedirectToAction("Create");
            }
        
        }
      
        public async Task<IActionResult> List()
        {
            return View(await offerServies.getAll());
        }
        public async Task<IActionResult> Delete(int id)
        {
            Offer offer = await offerServies.getById(id);
            if (offer == null)
                return BadRequest("Stock Not Found");
            return View(offer);

        }
        [HttpPost]

        public async Task<IActionResult> Delete(Offer offer)
        {
    
            try
            {
                await offerServies.Delete(offer);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Delete");
            }
        }
        public async Task <IActionResult> Edit(int id)
        {
            Offer offer = await offerServies.getById(id);
            if (offer == null)
                return BadRequest("This Catagory Is Not Found");
            return View(offer);

        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id,[FromForm] Offer offer)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    await offerServies.Update(offer);
                    return RedirectToAction("List");

                }
                else
                     return BadRequest("Plese Try Again");
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Edit");
            }

        }

    }
}
