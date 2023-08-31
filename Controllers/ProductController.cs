using e_commerce.Models;
using e_commerce.Servies;
using e_commerce.ViewModel;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServies productServies;
        private readonly IOfferServies offerServies;
        private readonly ICatagoryServies catagoryServies;

        public ProductController(IProductServies _productServies,IOfferServies _offerServies,ICatagoryServies _catagoryServies)
        {
            productServies = _productServies;
            offerServies = _offerServies;
            catagoryServies = _catagoryServies;
           
        }
        [Authorize(Roles = ("Admin"))]

        public async Task <IActionResult> Create()
        {
            IEnumerable <Catagory> catagories= await catagoryServies.getAll();
            IEnumerable <Offer> offers= await offerServies.getAll();
            ViewData["cat"] = catagories;
            ViewData["offer"] = offers;
      
            //  ViewData["stock"] = stocks;
            return View();
        }
       [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = ("Admin"))]
       public async Task<IActionResult>Create([FromForm]EditProductViewModel newproduct)
       {

            try
            {
                Product product = new Product();

                using (var DataStream = new MemoryStream())
                {
                    await newproduct.Photo.CopyToAsync(DataStream);
                    byte[] data = DataStream.ToArray();
                    product.Name = newproduct.Name;
                    product.Description = newproduct.Description;
                    product.Photo = data;
                    product.Price = newproduct.Price;
                    product.Create_at = DateTime.Now;
                    if (newproduct.CatagortId == 0)
                        product.CatagoryId = 1;
                    else product.CatagoryId = newproduct.CatagortId;
                    if (newproduct.OfferId == 0)
                        product.OfferId = 1;
                    else
                    product.OfferId = newproduct.OfferId;
                };
                  await productServies.Create(product);
                  return RedirectToAction("List");

              
               
                    
                // return Content("Create is Done");
             
            }
            catch (Exception ex) {
                ModelState.AddModelError("Exception","Plese Enter Valid Input ");
                return BadRequest("Be Carful And Try Again");

            }
        }
        public async Task<IActionResult> List()
        {
            return View(await productServies.getAll());
        }
        public async Task<IActionResult> Search(int id)
        {
            var product = await productServies.getById(id);
            if (product is null)
                return BadRequest("Product not found");

            return View(product);
        }
        public async Task<ActionResult> Details(int id)
        {
            Product product =await productServies.getById(id);
             ViewData["catagory"] = await productServies.getCatagory(product.CatagoryId);
             ViewData["offer"] = await productServies.getOffer(product.OfferId);

            if (product == null)
                return BadRequest("This Product Is Not Found ");
            return View(product);
        }
        [Authorize(Roles = ("Admin"))]

        public async Task<ActionResult> Edit(int id)
        {
            Product product=await productServies.getById(id);
            IEnumerable<Catagory> catagories = await catagoryServies.getAll();
            IEnumerable<Offer> offers = await offerServies.getAll();
            ViewData["cat"] = catagories;
            ViewData["offer"] = offers;
            if (product == null)
                return BadRequest("This Product Is Not Found ");
            return View(product);
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = ("Admin"))]

        public async Task<ActionResult> Edit(int id,[FromForm]Product product,IFormFile photo)
        {
            try
            {

                Product oldproduct = await productServies.getById(id);

                if (photo is not null)
                {
                    using (var DataStream = new MemoryStream())
                    {
                        await photo.CopyToAsync(DataStream);
                        byte[] data = DataStream.ToArray();
                      
                       await productServies.Update(id ,product, data);
                        
                    }
                }
                else if (photo is null)
                {
                    await productServies.Update(id, product);

                }
                else
                    return BadRequest("This Product Is Not Found ");
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Edit");
            }
     }
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await productServies.getById(id);
            ViewData["catagory"] = await productServies.getCatagory(product.CatagoryId);
            ViewData["offer"] = await productServies.getOffer(product.OfferId);
            if (product == null)
                return BadRequest("Product Not Found");
            return View(product);

        }
        [HttpPost]

        public async Task<IActionResult> Delete(Product product)
        {

            try
            {
                await productServies.Delete(product);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return RedirectToAction("Delete");
            }
        }

    }
}
