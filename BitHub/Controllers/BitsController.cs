﻿using BitHub.Models;
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