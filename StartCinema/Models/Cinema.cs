using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCinema.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Name")]
        public string CinemaName { get; set; }
        [Column("Manager")]
        public string CinemaManager { get; set; }
        [Column("Address")]
        public string CinemaAddress { get; set; }
        [Column("Phone")]
        public string CinemaPhone { get; set; }
        [Column("SeatCapacity")]
        public int CinemaSeatCapacity { get; set; }

    }
}