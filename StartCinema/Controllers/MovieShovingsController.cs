using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using StartCinema.Models;
using StartCinema.ViewModel;

namespace StartCinema.Controllers
{
    public class MovieShovingsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        // GET: MovieShovings

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

           

            ViewBag.CurrentFilter = searchString;

            var mshow = from m in _context.MovieShovings
                select m;
            switch (sortOrder)
            {
                case "name_desc":
                    mshow = mshow.OrderByDescending(s => s.Movie.NameOfMovie);
                    break;
                case "Date":
                    mshow = mshow.OrderBy(s => s.FromDate);
                    break;
                
                default:
                    mshow = mshow.OrderBy(s => s.Movie.NameOfMovie);
                    break;
            }
           

            var model = _context.MovieShovings.Include(x => x.Movie).Include(y => y.Cinema).ToList();
            return View(mshow);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create(MovieShovingViewModel model)
        {
           



            

            ViewBag.Movies = new SelectList(_context.Movies, "MovieId", "NameOfMovie");

            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "CinemaName");


            /*ApplicationDbContext myEntity = new ApplicationDbContext();
            var getCinemalist = myEntity.Cinemas.ToList();
            SelectList cinemaList = new SelectList(getCinemalist, "Id", "CinemaName");
            ViewBag.cinemalistname = cinemaList;

            ApplicationDbContext myEntity2 = new ApplicationDbContext();
            var getMovieList = myEntity2.Movies.ToList();
            SelectList movieList = new SelectList(getMovieList, "MovieId", "NameOfMovie");
            ViewBag.movielistname = movieList;*/

            var movieShoving = new MovieShoving();
            if (model == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                movieShoving.Id = model.Id;
                movieShoving.CinemaId = model.CinemaId;
                movieShoving.MovieId = model.MovieId;
                movieShoving.FromDate = model.FromDate;
                movieShoving.ToDate = model.ToDate;
                

                _context.MovieShovings.Add(movieShoving);
                _context.Entry(movieShoving).State = EntityState.Added;
                _context.SaveChanges();
                ModelState.Clear();


                var rows = _context.RowSeats.ToList();

                foreach (var row in rows)
                {
                    var entity = new MovieSeats
                    {
                        RowSeatId = row.Id,
                        RefSeatStatusId = _context.RefSeatStatuses.FirstOrDefault(x => x.SeatStatus.Equals(false)).Id,
                        MovieId = model.MovieId,
                        DateMovie = model.FromDate
                    };
                    _context.MovieSeatses.Add(entity);
                    _context.SaveChanges();
                }

            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Movies = new SelectList(_context.Movies, "MovieId", "NameOfMovie");

            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "CinemaName");
            var model = new MovieShovingViewModel();
            var result = _context.MovieShovings.FirstOrDefault(x => x.Id.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }

            model.Id = result.Id;
            model.CinemaId = result.CinemaId;
            model.MovieId = result.MovieId;
            model.FromDate = result.FromDate;
            model.ToDate = result.ToDate;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieShovingViewModel model)
        {

            ViewBag.Movies = new SelectList(_context.Movies, "MovieId", "NameOfMovie");

            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "CinemaName");

            if (ModelState.IsValid)
            {
                var movieShoving = _context.MovieShovings.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                if (movieShoving != null)
                {
                    movieShoving.Id = model.Id;
                    movieShoving.CinemaId = model.CinemaId;
                    movieShoving.MovieId = model.MovieId;
                    movieShoving.FromDate = model.FromDate;
                    movieShoving.ToDate = model.ToDate;
                  

                    _context.MovieShovings.Attach(movieShoving);
                    _context.Entry(movieShoving).State = EntityState.Modified;
                    _context.SaveChanges();
                }


            }
            return View(model);
        }

        public ActionResult Reserve(int id, int id2)
        {


            var model = _context.MovieShovings.Where(x => x.MovieId.Equals(id)).Include(x => x.Cinema).Include(x => x.Movie).FirstOrDefault();
            var rowSeats = _context.MovieSeatses.Include("RowSeat").Where(x => x.MovieId.Equals(id)).ToList();
            //var z3312 = _context.MovieSeatses.Include("RowSeat").Where(x => x.RowSeat.CinemaId.Equals(id2)).ToList();
            var result = new ReserveViewModel
            {
                Movie = model,
                RowSeat = rowSeats
            };
            return View(result);

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
             
            var model = new MovieShoving();
            var result = _context.MovieShovings.FirstOrDefault(x => x.Id.Equals(id));

            if (result == null)
            {
                return HttpNotFound();
            }

            model.Id = result.Id;
            model.MovieId = result.MovieId;
            model.CinemaId = result.CinemaId;
            model.FromDate = result.FromDate;
            model.ToDate = result.ToDate;
           


            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, MovieShoving movie1)
        {
            try
            {
                
                MovieShoving movie = _context.MovieShovings.Where(m => m.Id == id).FirstOrDefault();
                _context.Entry(movie).State = EntityState.Deleted;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie1);
            }
        }

        public ActionResult GetResult(DateTime? searching)
        {
            if (searching != null)
            {
                var model = _context.MovieShovings.Include(x => x.Movie)
                    .Include(y => y.Cinema).Where(x => x.FromDate.Value.Day.Equals(searching.Value.Day) && x.FromDate.Value.Month.Equals(searching.Value.Month)).ToList();

                return View("Index", model);

            }

            var result = _context.MovieShovings.Include(x => x.Movie).Include(y => y.Cinema).ToList();
            return View("Index", result);
        }
    }
}