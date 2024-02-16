using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatchMore.Models.ViewModels
{
    public class SessionVM
    {
        public Session Session { get; set; }
        public IEnumerable<SelectListItem> SessionList { get; set; }
    }
}
