using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestTask.Models;

namespace TestTask.Controllers
{

    public class HomeController : Controller
    {

        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order) // возвращаем не стрингу, как в примере, а "IActionResult"
        {
            order.UserId = db.Users.First(x => x.Email.Equals(User.Identity.Name)).Id;
          // order.UserId = db.Phones.First(x =>x.Id.Equals(order.PhoneId)).Id;
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("ThxPage", order.User); // Делаем редирект на метод ThxPage, а вторым парметром передаем этот же заказ.
        }
        public IActionResult ThxPage(User user)
        {
            ViewBag.User = user; //Передаем в "сумку" экземпляр недавнего заказа.
            return View();
        }
    }
}