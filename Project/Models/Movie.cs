using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Movie
    {
        [Key]
        public int Movie_Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        [DisplayName("Movie Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre is Required")]
        [DisplayName("Movie Genre")]
        public string Genre1 { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        [DisplayName("Movie Duration")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DisplayName("Movie Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        [DisplayName("Movie Rating")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "The Image field is required.")]
        [Display(Name = "Image")]
        [DefaultValue("default.png")]

        public string Movie_Pic { get; set; }


        [ForeignKey("AdminID")]
        public Admin? Admin { get; set; }



        [ForeignKey("HallID")]
        public Hall? Hall { get; set; }

        [ForeignKey("GenreID")]
        public Genre? Genre { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
    }
}