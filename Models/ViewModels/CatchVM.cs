using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatchMore.Models.ViewModels
{
    public class CatchVM
    {
        public Catch Catch { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SessionList { get; set; }
    }
}
