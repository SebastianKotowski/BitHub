using BitHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitHub.ViewModels
{
    public class BitFormViewModel
    {
        
        [Required]
        public string Venue { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format($"{Date} {Time}"));
        }
    }
}