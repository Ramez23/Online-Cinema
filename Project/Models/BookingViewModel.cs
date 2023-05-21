namespace Project.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public List<Seat> Seats { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

    }
}
