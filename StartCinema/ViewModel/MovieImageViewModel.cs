using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartCinema.ViewModel
{
    public class MovieImageViewModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "Image Name")]
        public string Title { get; set; }

        [StringLength(30)]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}