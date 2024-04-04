using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTGFront_Back.Models
{
    public class BoosterPackViewModel
    {
        public List<SelectListItem> SetList { get; set; }
        public string SelectedSet { get; set; }
        public SimplifiedCardListModel SimplifiedCardListModel { get; set; } = new SimplifiedCardListModel();
    }
}
