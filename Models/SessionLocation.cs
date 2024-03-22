using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchMore.Models
{
    public class SessionLocation
    {
        [Required]
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        [Required]
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
    }
}
