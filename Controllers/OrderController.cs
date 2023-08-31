using e_commerce.Models;
using e_commerce.Servies;
using e_commerce.ViewModel;
using First_MVC.Servies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServies orderServies;
        private readonly ICartServies cartServies;
        private readonly IProductServies productServies;
        private readonly UserManager<IdentityUser> userManager;

        public OrderController(IOrderServies _orderServies,ICartServies _cartServies,IProductServies _productServies,UserManager<IdentityUser> _userManager)
        {
            orderServies = _orderServies;
            cartServies = _cartServies;
            productServies = _productServies;
            userManager = _userManager;
        }
        public IActionResult Create(double total)
        {
            
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([FromForm]OrderViewModel newOrder)
       {
            try
            {
                var userId = userManager.GetUserId(User);
                IEnumerable<Cart> cart = cartServies.GetAll(userId);
                OrderDeteils orderDeteils = new OrderDeteils
                {
                    Name = newOrder.Name,
                    Adress = newOrder.Address,
                    Phone = newOrder.Phone,
                    UserID = userId,
                    CreatedDate = DateTime.Now,
                    Total=newOrder.TotalAmount
                };
                int id = await orderServies.CreateOrderDeteils(orderDeteils);

                Order order = new Order();
                order.OrderDetailsId = id;

                foreach (var item in cart)
                {
                    order.ProuductId += item.ProductId;
                    order.Quantity += item.Quantity;
                    order.Price += orderDeteils.Total*item.Quantity;
                };
                    await orderServies.CreateOrder(order);
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", "Something Was Wrong");
                return View();
            }
        }


       public async Task <IActionResult> MyOrder()
        {
            var userId =userManager.GetUserId(User);
            return View(await orderServies.MyOrders(userId));

        }

       public async Task <IActionResult> Delete(int id)
        {
            try
            {
                OrderDeteils order = await orderServies.getById(id);
                if (order == null)
                    return NotFound("Sorry I Can Not Found ");
                else
                {
                    await orderServies.DeleteOrder(order);
                    return RedirectToAction("MyOrder");
                }
            }
            catch (Exception ex){
                ModelState.AddModelError("Exception", "Something Was Wrong");
                return RedirectToAction("MyOrder");
            }
        }



    }
}
