using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrafficFineSystemWeb.Models.ViewModel
{
    public class FineVM
    {

        public FineModel Fine { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DriverList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> TrafficList { get; set; }

    }
}
