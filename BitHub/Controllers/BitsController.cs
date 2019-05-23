using BitHub.Models;
using BitHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new BitFormViewModel()
            {
                Genres = db.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(BitFormViewModel viewModel)
        {
            var bit = new Bit()
            {
                ArtistId = User.Identity.GetUserId(),
                Date = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            db.Bits.Add(bit);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}