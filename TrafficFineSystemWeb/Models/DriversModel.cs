using System.ComponentModel.DataAnnotations;

namespace TrafficFineSystemWeb.Models
{
    public class DriversModel
    {
        [Key]
        public string VechileNumber { get; set; }

        
        public string LicenseNumber { get; set; }
        public string Name { get; set; }

        public string? VechineType { get; set; }

        public string? Address { get; set; }
        public string? Email { get;set; }

    }
}
