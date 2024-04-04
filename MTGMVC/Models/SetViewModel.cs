using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTGMVC.Models
{
    public class SetViewModel
    {
        public List<SelectListItem> SetList { get; set; }
        public string SelectedSet { get; set; }
    }
}
