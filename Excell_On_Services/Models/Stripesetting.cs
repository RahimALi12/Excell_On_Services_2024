using System.ComponentModel.DataAnnotations;

namespace Excell_On_Services.Models
{
    public class Stripesetting
    {

        [Key]

        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }

    }
}
