using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Seat
    {
        [Key]
        public int Seat_Id { get; set; }
        [Required]
        public int Seat_Num { get; set; }
        public Boolean IsSold { get; set; }
        
        [ForeignKey("HallID")]
        public Hall? Hall { get; set; }
    }
}
