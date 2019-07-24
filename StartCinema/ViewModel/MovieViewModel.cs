using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using StartCinema.Models;

namespace StartCinema.ViewModel
{
    public class MovieViewModel
    {
        
        public int MovieId { get; set; }
        
        [Required]
        [Display(Name = "Title *")]
        public string NameOfMovie { get; set; }

        [Display(Name = "Country *")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Genre *")]
        [Required]
        public string Genre { get; set; }

        [Display(Name ="Duration(min) *")]
        [Required]
        public int? Duration { get; set; }

        [Display(Name = "Age *")]
        [Required]
        public int? Age { get; set; }

        [Display(Name = "Description *")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Rating *")]
        [Required]
        public float? Rating { get; set; }

        
        
        

        
        public HttpPostedFileBase ImageFile { get; set; }



        


        
        




    }

   
}