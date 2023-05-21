using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace Project.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment;

        public MoviesController(ApplicationDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.acsses = HttpContext.Session.GetString("acsses");
            return _context.Movies != null ?
                          View(await _context.Movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBcontext.Movies'  is null.");
            var Email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            return View();
        }

        public async Task<IActionResult> Booking()
        {
            var viewModel = new BookingViewModel
            {
                Movies = _context.Movies.ToList(), // Replace with your actual data access code
                Seats = _context.Seats.ToList(), // Replace with your actual data access code
            };
            return View(viewModel);
            //ViewBag.acsses = HttpContext.Session.GetString("acsses");
            //return _context.Movies != null ?
            //              View(await _context.Movies.ToListAsync()) :
            //              Problem("Entity set 'ApplicationDBcontext.Movies'  is null.");
            //var Email = HttpContext.Session.GetString("Email");
            //if (string.IsNullOrEmpty(Email))
            //{
            //    return View();
            //}
            //return View();
        }
        public async Task<IActionResult> Search(string searchTerm, string genre)
        {
            ViewBag.searchTerm = searchTerm;
            ViewBag.filter = genre;
            if (searchTerm == null && genre == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.acssess = HttpContext.Session.GetString("acsses");
            return _context.Movies != null ?
                          View(await _context.Movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBcontext.Movies'  is null.");
            return View();
        }



    }
}
