using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excell_On_Services.Models
{
    public class ClientServices
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientServices_Name { get; set; }

        public string Client_Id { get; set; }

        //----Navigation property------s
        [ForeignKey("Client_Id")]
        public virtual AppUser appUser { get; set; }

        [Required]
        public string ClientServices_Description { get; set; }

        [Required]
        public string ClientServices_Duration { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public int Services_Id { get; set; }

        //----Navigation property------
        [ForeignKey("Services_Id")]
        public virtual Services Service { get; set; }

    }
}
