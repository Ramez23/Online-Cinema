using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public ReservationsController(ApplicationDBcontext context)
        {
            _context = context;
        }
        public IActionResult Book()
        {
            var viewModel = new BookingViewModel
            {
                Movies = _context.Movies.ToList(),
                Reservations = _context.Reservations.ToList(),
                Seats = _context.Seats.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Book(Reservation reservation, DateTime Time)
        {
            if (ModelState.IsValid)
            {
                var UserId = await _context.Users.FirstOrDefaultAsync(u => u.Id == reservation.User_Id);
                var maxPayId = await _context.Reservations.MaxAsync(r => r.Pay_Id);
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Movie_Id == reservation.M_Id);
          
                var seat = _context.Seats.FirstOrDefault(s => s.Seat_Num == reservation.Seat_Id && s.Hall.Hall_Id == movie.Hall.Hall_Id);

                if (seat.IsSold == false)
                {
                    // Increment each ID by 1
                    reservation.Pay_Id = maxPayId + 1;
                    reservation.Date = movie.Date;
                    _context.Add(reservation);
                    seat.IsSold = true;
                    _context.Entry(seat).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    return RedirectToAction("Booking", "Movies");
                }
            }
            return View(reservation);
        }
    }
}
