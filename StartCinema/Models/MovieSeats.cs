using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartCinema.Models
{
    public class MovieSeats
    {
        [Key]
        public int Id { get; set; }

        public RowSeat RowSeat { get; set; }
        public int RowSeatId { get; set; }

        public RefSeatStatus RefSeatStatus { get; set; }
        public int RefSeatStatusId { get; set; }


        public Booking Booking { get; set; }
        public int? BookingId { get; set; }


        public Movie Movie { get; set; }
        public int MovieId { get; set; }

       

        public DateTime? DateMovie { get; set; }
    }
}