using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Reservation
    {
        [Key]
        public int Res_Id { get; set; }
        [Required(ErrorMessage = "UserID is Required")]
        public int User_Id { get; set; }
        [Required(ErrorMessage = "MovieID is Required")]
        public int M_Id { get; set; }
        [Required(ErrorMessage = "SeatID is Required")]
        public int Seat_Id { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        public DateTime Date { get; set; }
        public int Pay_Id { get; set; }
        [Required(ErrorMessage = "HallID is Required")]
        public int TicketCount { get; set; }
        public int Hall_Id { get; set; }

        [ForeignKey("MovieID")]
        public Movie? Movie { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
        public virtual ICollection<Seat>? Seats { get; set; }
    }
}
