using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartCinema.ViewModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone *")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your Email *")]
        public string Mail { get; set; }

        public string Description { get; set; }


        [Display(Name = "Booking Made Date")]
        public DateTime? BookingMadeDate { get; set; }

        public bool Cola { get; set; }
        public bool Popcorn { get; set; }

        public List<ColumnRowDto> ColumnRows { get; set; }

        public string Rows { get; set; }
        public string Columns { get; set; }

        public string SeatCount { get; set; }
    } 
}