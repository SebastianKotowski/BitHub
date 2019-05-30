using BitHub.Models;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System;

namespace BitHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController ()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcommingBits = db.Bits
                .Include(b => b.Artist)
                .Include(g => g.Genre)
                .Where(b => b.Date > DateTime.Now);

            return View(upcommingBits);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}