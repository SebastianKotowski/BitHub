using BitHub.Models;
using BitHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BitHub.Controllers
{
    public class BitsController : Controller
    {
        private readonly ApplicationDbContext db;

        public BitsController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new BitFormViewModel()
            {
                Genres = db.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}