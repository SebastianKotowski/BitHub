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
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext db;

        public AttendancesController()
        {
            db = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if(db.Attendences.Any(a => a.AttendeeId == userId && a.BitId == dto.BitId))
            {
                return BadRequest("The attendance already exists");
            }

            var attendance = new Attendance
            {
                BitId = dto.BitId,
                AttendeeId = userId
            };

            db.Attendences.Add(attendance);
            db.SaveChanges();

            return Ok();
        }
    }
}
