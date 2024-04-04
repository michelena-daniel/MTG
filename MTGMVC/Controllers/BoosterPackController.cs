using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MTGFront_Back.Models;
using MTGFront_Back.Services;
using MTGFront_Back.DTOs.Custom;

namespace MTGFront_Back.Controllers
{
    public class BoosterPackController : Controller
    {
        private readonly ILogger<BoosterPackController> _logger;
        private IMTGService _service;
        private IMagicDataWriterService _dataWriterService;

        public BoosterPackController(ILogger<BoosterPackController> logger, IMTGService service, IMagicDataWriterService dataWriterService)
        {
            _logger = logger;
            _service = service;
            _dataWriterService = dataWriterService;
        }

        public async Task<IActionResult> BoosterSet(BoosterPackViewModel model)
        {
            var sets = await _dataWriterService.GetAllSetNamesAsync();
            model.SetList = [];

            foreach (var set in sets)
            {
                model.SetList.Add(new SelectListItem { Text = set.Name, Value = set.Code });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BoosterSelected(BoosterPackViewModel model)
        {
            if (model.SelectedSet == "defaultoption")
            {
                return RedirectToAction("BoosterSet");
            }
            try
            {
                var booster = await _service.GetBoosterPack(model.SelectedSet);

                model.SimplifiedCardListModel.SimplifiedCardList = booster;

                return View(model);
            }
            catch
            {
                return RedirectToAction("BoosterError");
            }            
        }

        public IActionResult BoosterError()
        {
            return View();
        }

        public IActionResult RedirectToBooster()
        {
            return RedirectToAction("BoosterSet");
        }
    }
}
