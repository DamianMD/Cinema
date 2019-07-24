using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCinema.Models;

namespace StartCinema.ViewModel
{
    public class ReserveViewModel
    {
        public MovieShoving Movie { get; set; }
        public MovieShoving Cinema { get; set; }
        public List<MovieSeats> RowSeat { get; set; }

        public string Rows { get; set; }
        public string Columns { get; set; }
    }

    public class ColumnRowDto
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}