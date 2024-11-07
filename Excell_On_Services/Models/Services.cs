using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excell_On_Services.Models
{
    public class Services
    {
        [Key]
        public int Service_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Service_Name { get; set; }

        [Required]
        public decimal ServiceChargesPerMonth { get; set; }
    }
}
