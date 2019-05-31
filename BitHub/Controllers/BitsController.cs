using BitHub.Models;
using BitHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var bits = db.Attendences
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Bit)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            ViewBag.Heading = "Bits I'm Attending";

            return View("Bits", bits);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(BitFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Genres = db.Genres.ToList();

                return View("create", viewModel);
            }

            var bit = new Bit()
            {
                ArtistId = User.Identity.GetUserId(),
                Date = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            db.Bits.Add(bit);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}