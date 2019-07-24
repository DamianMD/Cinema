using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCinema.Models
{
    public class RowSeat
    {
        [Key]
        
        public int Id { get; set; }

        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }

        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

    }
}