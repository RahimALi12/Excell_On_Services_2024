using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excell_On_Services.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Contact { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
    }
}
