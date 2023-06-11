using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficFineSystemWeb.Models
{
    public class FineModel
    {
        [Key]
        public int FineId { get; set; }
        public string LicenseNumber { get; set; }

        public string VehicleNumber { get; set; }
        public string FineType { get; set; }

        public string Amount { get; set; }


        [Required]
        [Display(Name = "DriversAdd")]
        public string DriverId { get; set; }
        [ForeignKey("DriverId")]
        [ValidateNever]

        public DriversModel DriversAdd { get; set; }



        [Required]
        [Display(Name = "TrafficAdd")]
        public int TrafficId { get; set; }
        [ForeignKey("TrafficId")]
        [ValidateNever]

        public TrafficModel TrafficAdd { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
