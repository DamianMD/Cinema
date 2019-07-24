using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace StartCinema.Models
{
    public class RefSeatStatus
    {
        [Key]
        public int Id { get; set; }
        public bool SeatStatus { get; set; }
    }
}