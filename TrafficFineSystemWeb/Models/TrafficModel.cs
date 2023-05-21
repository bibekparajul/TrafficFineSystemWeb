using System.ComponentModel.DataAnnotations;

namespace TrafficFineSystemWeb.Models
{
    public class TrafficModel
    {
        [Key]
        public int TrafficId { get; set; }
        public string Name { get; set; }

        public string Post { get; set; }    

        public string City { get; set; }

        public string Area { get;set; }
    }
}
