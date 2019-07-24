using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;

namespace StartCinema.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Display(Name = "Movie Name")]
        public string NameOfMovie { get; set; }
        public string Country { get; set; }
        public int? Duration { get; set; }
        public int? Age { get; set; }
        public string Description { get; set; }
        public float? Rating { get; set; }
        public string Image { get; set; }

        


        public string Genre { get; set; }
       

       

    }

    
    
}