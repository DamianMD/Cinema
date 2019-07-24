using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using PagedList;
using StartCinema.Models;
using StartCinema.ViewModel;



namespace StartCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Movie
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "name";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var movies = from m in _context.Movies
                select m;
            switch (sortOrder)
            {
                case "name":
                    movies = movies.OrderBy(m => m.NameOfMovie);
                    break;
                case "Rating":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                
                default:
                    movies = movies.OrderBy(m => m.NameOfMovie);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(movies.ToPagedList(pageNumber, pageSize));


            //return View(_context.Movies.ToList());

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieViewModel model)
        {
            var movie = new Movie();
           

                if (ModelState.IsValid)
                {
                    movie.MovieId = model.MovieId;
                    movie.NameOfMovie = model.NameOfMovie;
                    movie.Country = model.Country;
                    movie.Duration = model.Duration;
                    movie.Age = model.Age;
                    movie.Description = model.Description;
                    movie.Rating = model.Rating;
                    movie.Genre = model.Genre;
                    










                    _context.Movies.Add(movie);
                    _context.Entry(movie).State = EntityState.Added;
                    _context.SaveChanges();
                    ModelState.Clear();
                }
                else
                {
                    return View(model);
                }
            

            return RedirectToAction("Index");

        }



        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            
            var model = new MovieViewModel();
            var result = _context.Movies.FirstOrDefault(x => x.MovieId.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }

            model.MovieId = result.MovieId;
            model.NameOfMovie = result.NameOfMovie;
            model.Country = result.Country;
            model.Duration = result.Duration;
            model.Age = result.Age;
            model.Description = result.Description;
            model.Rating = result.Rating;
            model.Genre = result.Genre;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var movie = _context.Movies.AsNoTracking().FirstOrDefault(x => x.MovieId == model.MovieId);
                if (movie != null)
                {
                    movie.NameOfMovie = model.NameOfMovie;
                    movie.Country = model.Country;
                    movie.Duration = model.Duration;
                    movie.Age = model.Age;
                    movie.Description = model.Description;
                    movie.Rating = model.Rating;
                    movie.Genre = model.Genre;

                    _context.Movies.Attach(movie);
                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var model = new MovieViewModel();
            var result = _context.Movies.FirstOrDefault(x => x.MovieId.Equals(id));

            if (result == null)
            {
                return HttpNotFound();
            }

            model.MovieId = result.MovieId;
            model.NameOfMovie = result.NameOfMovie;
            model.Country = result.Country;
            model.Duration = result.Duration;
            model.Age = result.Age;
            model.Description = result.Description;
            model.Rating = result.Rating;
            model.Genre = result.Genre;


            return View(model);
        }

  
        [HttpPost]
        public ActionResult Delete(int id, Movie movie1)
        {
            try
            {
                Movie movie = _context.Movies.ToList().Where(m => m.MovieId == id).FirstOrDefault();
                _context.Entry(movie).State = EntityState.Deleted;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


      
    }
}