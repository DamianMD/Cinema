using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartCinema.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public DateTime? BookingMadeDate { get; set; }
        public bool Cola { get; set; }
        public bool Popcorn { get; set; }

        public string SeatCount { get; set; }
    }
}