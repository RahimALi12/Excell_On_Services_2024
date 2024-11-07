using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excell_On_Services.Models
{
    public class Contact
    {

        [Key]
        public int Contact_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Contact_Name { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Contact_Email { get; set; }


        [Required]
        [Phone]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Please enter a valid 11-digit phone number.")]
        public string Contact_Phone { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Contact_Subject { get; set; }


        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Contact_Message { get; set; }
    }
}
