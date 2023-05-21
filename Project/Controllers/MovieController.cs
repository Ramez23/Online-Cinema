using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Microsoft.Extensions.Hosting;

namespace Project.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDBcontext _context;
		private readonly IWebHostEnvironment _environment;

		public MovieController(ApplicationDBcontext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
   

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            ViewBag.acssess = HttpContext.Session.GetString("acsses");
            return _context.Movies != null ? 
                          View(await _context.Movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBcontext.Movies'  is null.");
              
            
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Movie_Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            ViewBag.GenreType = new SelectList(_context.Genres, "Id", "GenreType");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movie_Id,Genre1,Title,Duration,Date,Rating")] Movie movie, IFormFile img_file)
        {
			
			// to create Images folder in the project Path.
			string path = Path.Combine(_environment.WebRootPath, "Images"); // wwwroot/Img/
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (img_file != null)
			{
				path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await img_file.CopyToAsync(stream);
					//ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                    movie.Movie_Pic=img_file.FileName;
				}
			}
            else
            {
                movie.Movie_Pic = "default.jpeg"; // to save the default image path in database.
            }
            try
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }

            return View();


		}

		// GET: Movie/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var existingMovie = await _context.Movies.FindAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = movie.Title;
            existingMovie.Genre1 = movie.Genre1;
            existingMovie.Duration = movie.Duration;
            existingMovie.Date = movie.Date;
            existingMovie.Rating = movie.Rating;
            existingMovie.Movie_Pic = movie.Movie_Pic;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Movie_Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDBcontext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Movie_Id == id)).GetValueOrDefault();
        }
    }
}
