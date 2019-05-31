using BitHub.Dtos;
using BitHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext db;

        public FollowingsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (db.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Follwoing already exists");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            db.Followings.Add(following);
            db.SaveChanges();

            return Ok();
        }
    }
}
