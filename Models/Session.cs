using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatchMore.Models
{
    public class Session : DataEntity
    {
        [Required]
        [DisplayName("Session Name")]
        public string SessionName { get; set; }
        [Required]
        [DisplayName("Session Date")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        [Required]
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
