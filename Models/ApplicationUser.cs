using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CatchMore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserNameHandle { get; set; }
    }
}
