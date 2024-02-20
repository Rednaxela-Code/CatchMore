using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatchMore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Latitude")]
        public string UserNameHandle { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
