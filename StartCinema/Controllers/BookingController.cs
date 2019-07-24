using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using StartCinema.Models;
using StartCinema.ViewModel;

namespace StartCinema.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Booking
        public ActionResult Index()
        {

            return View(_context.Movies.ToList());
            
        }

        [HttpGet]
        public ActionResult Create(ReserveViewModel model)
        {

            /*var rows = model.Rows.Split(',').Select(int.Parse).ToList();
            var columns = model.Columns.Split(',').Select(int.Parse).ToList();

            var Selected = new List<ColumnRowDto>();

            for (int i = 0; i < rows.Count; i++)
            {
                Selected.Add(new ColumnRowDto
                {
                    Row = rows[i],
                    Column = columns[i]
                });
            }*/

            var result = new BookingViewModel()
            {
                Rows = model.Rows,
                Columns = model.Columns
            };


            return View(result);

        }

        [HttpPost]
        public ActionResult Create(BookingViewModel model)
        {

            model.BookingMadeDate = DateTime.Today;

            if (ModelState.IsValid)
            {
                var booking = new Booking
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Mail = model.Mail,
                    Description = model.Description,
                    BookingMadeDate = model.BookingMadeDate,
                    Cola = model.Cola,
                    Popcorn = model.Popcorn,
                };




                _context.Bookings.Add(booking);
                _context.Entry(booking).State = EntityState.Added;
                _context.SaveChanges();
                ModelState.Clear();


                var rows = model.Rows.Split(',').Select(int.Parse).ToArray();
                var columns = model.Columns.Split(',').Select(int.Parse).ToArray();

                for (int i = 0; i < rows.Length; i++)
                {
                    var tempRow = rows[i];
                    var tempColumn = columns[i];
                    var seatId = _context.RowSeats.FirstOrDefault(x => x.RowNumber.Equals(tempRow) && x.SeatNumber.Equals(tempColumn));
                    var entity = _context.MovieSeatses.FirstOrDefault(x => x.RowSeatId.Equals(seatId.Id));

                    
                    
                    entity.BookingId = booking.Id;
                    var entity2 = _context.Bookings.FirstOrDefault(x => x.Id.Equals(booking.Id));
                    entity2.SeatCount = booking.SeatCount + tempRow + "/" + tempColumn + "; ";
                    entity.RefSeatStatusId = _context.RefSeatStatuses.FirstOrDefault(x => x.SeatStatus.Equals(true)).Id;

                   
                    _context.MovieSeatses.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                    
                    _context.Bookings.Attach(entity2);
                    _context.Entry(entity2).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return RedirectToAction("Details", "Booking", new { id = booking.Id });
            }
            else
            {
                return View(model);
            }



            
                
            
        }

        public ActionResult Details(int id)
        {
            Booking book = _context.Bookings.Find(id);
            return View(book);
        }
        
    }
}