using System.ComponentModel.DataAnnotations;

namespace NajotTalim.HR.API.Models
{
    public class AdressModel
    {
        public int Id { get; set; }

        [Required]
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
