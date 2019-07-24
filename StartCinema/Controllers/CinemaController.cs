using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using StartCinema.Models;
using StartCinema.ViewModel;

namespace StartCinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Cinema
        public ActionResult Index()
        {
            return View(_context.Cinemas.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(CinemaViewModel model)
        {
            var cinema = new Cinema();
            if (model == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                cinema.CinemaName = model.CinemaName;
                cinema.CinemaAddress = model.CinemaAddress;
                cinema.CinemaManager = model.CinemaManager;
                cinema.CinemaPhone = model.CinemaPhone;
                cinema.CinemaSeatCapacity = model.CinemaSeatCapacity;

               
                _context.Cinemas.Add(cinema);
                _context.Entry(cinema).State = EntityState.Added;
                _context.SaveChanges();
                ModelState.Clear();


            }
            var result = new RowSeat();
            var rows = model.CinemaSeatCapacity / 10;
            var cinemaId = _context.Cinemas.FirstOrDefault(x => x.CinemaName.Equals(model.CinemaName)).Id;

            for (var i = 0; i < rows; i++)
            {
                result.RowNumber = i + 1;
                result.CinemaId = cinemaId;

                for (var j = 0; j < 10; j++)
                {
                    result.SeatNumber = j + 1;

                    _context.RowSeats.Add(result);
                    _context.Entry(result).State = EntityState.Added;
                    _context.SaveChanges();
                }
            }


            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = new CinemaViewModel();
            var result = _context.Cinemas.FirstOrDefault(x => x.Id.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }

            model.Id = result.Id;
            model.CinemaName = result.CinemaName;
            model.CinemaAddress = result.CinemaAddress;
            model.CinemaManager = result.CinemaManager;
            model.CinemaPhone = result.CinemaPhone;
            model.CinemaSeatCapacity = result.CinemaSeatCapacity;



            return View(model);
        }

        
        [HttpPost]
        public ActionResult Edit(CinemaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cinema = _context.Cinemas.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                if (cinema != null)
                {
                    cinema.CinemaName = model.CinemaName;
                    cinema.CinemaAddress = model.CinemaAddress;
                    cinema.CinemaManager = model.CinemaManager;
                    cinema.CinemaPhone = model.CinemaPhone;
                    cinema.CinemaSeatCapacity = model.CinemaSeatCapacity;

                _context.Cinemas.Attach(cinema);
                _context.Entry(cinema).State = EntityState.Modified;
                _context.SaveChanges();
                ModelState.Clear();
                }

            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var model = new CinemaViewModel();
            var result = _context.Cinemas.FirstOrDefault(x => x.Id.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }

            model.Id = result.Id;
            model.CinemaName = result.CinemaName;
            model.CinemaAddress = result.CinemaAddress;
            model.CinemaManager = result.CinemaManager;
            model.CinemaPhone = result.CinemaPhone;
            model.CinemaSeatCapacity = result.CinemaSeatCapacity;

            return View(model);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, CinemaViewModel cinema2)
        {
            try
            {
                Cinema cinema1 = _context.Cinemas.ToList().Where(c => c.Id == id).FirstOrDefault();
                _context.Entry(cinema1).State = EntityState.Deleted;
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