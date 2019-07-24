using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCinema.ViewModel
{
    public class CinemaViewModel
    {
      
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cinema Name")]
        public string CinemaName { get; set; }
        [Required]
        [Display(Name="Cinema Manager")]
        public string CinemaManager { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string CinemaAddress { get; set; }
        [Required][Phone][Display (Name= "Phone")]
        public string CinemaPhone { get; set; }
        [Required][Display(Name = "Seat Capacity")]
        public int CinemaSeatCapacity { get; set; }
    }
}