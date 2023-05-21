using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Hall
    {
        [Key]
        public int Hall_Id { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public int Hall_Num { get; set; }
    }
}
