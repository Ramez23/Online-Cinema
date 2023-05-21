using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailExist",controller: "User",ErrorMessage ="Email already exists")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "not match")]
        public string ConfirmPassword { get; set; }
        public string Phone_NUmber { get; set; }
        /*  public int AdminID { get; set; }
        
        [ForeignKey("AdminID")]
        public Admin? Admin { get; set; }


        public virtual ICollection<Reservation>? Reservations { get; set; }
        */
    }
}
