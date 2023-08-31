using e_commerce.Models;
using e_commerce.Servies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServies productServies;

        public HomeController(ILogger<HomeController> logger,IProductServies _productServies)
        {
            _logger = logger;
            productServies = _productServies;
        }
        public async Task <IActionResult> Index(int catagoryId)
        {
            return View(await productServies.getAll(catagoryId));
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult settings()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}