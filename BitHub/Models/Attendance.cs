using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BitHub.Models
{
    public class Attendance
    {
        public Bit Bit { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BitId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}