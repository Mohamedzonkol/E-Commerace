using e_commerce.Models;
using e_commerce.Servies;
using e_commerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = ("Admin"))]
    public class CatagoryController : Controller
    {
        private readonly ICatagoryServies catagoryServies;

        public CatagoryController(ICatagoryServies _catagoryServies)
        {
            catagoryServies = _catagoryServies;
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Catagory newCatagory)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    //Catagory catagory = new Catagory
                    //{
                    //    Name = newCatagory.Name,
                    //    Description = newCatagory.Description
                    //};
                    await catagoryServies.Create(newCatagory);
                    return RedirectToAction("List");

                }
                else
                {
                    return BadRequest("Please Check And Try Again");
                }
              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Create");
            }
        }
        public async Task<IActionResult> List()
        {
            return View(await catagoryServies.getAll());
        }
        public async Task<IActionResult> Delete(int id)
        {
            Catagory catagory = await catagoryServies.getById(id);
            if (catagory == null)
                return BadRequest("Catagory Not Found");
      
            return View(catagory);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Catagory catagory)
        {
            try
            {
                await catagoryServies.Delete(catagory);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Delete");
            }
        }
        public async Task<ActionResult> Edit(int id)
        {

            Catagory catagory = await catagoryServies.getById(id);
            if (catagory == null)
                return BadRequest("This Catagory Is Not Found");
            return View(catagory);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( [FromForm]Catagory catagory)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    await catagoryServies.Update(catagory);
                    return RedirectToAction("List");
                }
                else
                {
                    return BadRequest("Plese Try Again");
                }
              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Edit");
            }
            }
    }
}
