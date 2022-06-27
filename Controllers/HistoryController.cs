using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HistoryController : Controller
    {
        MobileContext db;
        public HistoryController(MobileContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult History()
        {
            var getPhones = db.Orders.Include(x => x.Phone);
            return View(getPhones.Where(o => o.UserId == db.Users.First(x => x.Email.Equals(User.Identity.Name)).Id).ToArray());
        }
    }
}
