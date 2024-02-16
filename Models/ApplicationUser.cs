using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatchMore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Latitude")]
        public string UserNameHandle { get; set; }
    }
}
