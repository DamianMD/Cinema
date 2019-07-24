using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartCinema.Models
{
    public class MovieShoving
    {
        [Key]
        public int Id { get; set; }

        
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

       
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Movie Date")]
        public DateTime? FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Movie Time")]
        public DateTime? ToDate { get; set; }

        

    }

    
}