using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Genre is Required")]
        public string GenreType { get; set; }
        [ForeignKey("AdminID")]
        public Admin? Admin { get; set; }
    }
}
