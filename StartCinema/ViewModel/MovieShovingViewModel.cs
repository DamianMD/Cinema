using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StartCinema.Models;

namespace StartCinema.ViewModel
{
    public class MovieShovingViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cinema *")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [Required]
        [Display(Name = "Movie *")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        [Display(Name = "Movie Date *")]
        public DateTime? FromDate { get; set; }

        [Required]
        [Display(Name = "Movie Time *")]
        public DateTime? ToDate { get; set; }


    }
}