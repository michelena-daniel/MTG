using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTGFront_Back.Models;
using MTGFront_Back.Services;
using System.Diagnostics;

namespace MTGFront_Back.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMTGService _service;
        private IMagicDataWriterService _dataWriterService;

        public HomeController(ILogger<HomeController> logger, IMTGService service, IMagicDataWriterService dataWriterService)
        {
            _logger = logger;
            _service = service;
            _dataWriterService = dataWriterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Card(SetViewModel model)
        {
            //var sets = await _service.GetAllSets();
            var sets = await _dataWriterService.GetAllSetNamesAsync();
            model.SetList = [];

            foreach(var set in sets)
            {
                model.SetList.Add(new SelectListItem { Text = set.Name, Value = set.Code });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetSelectedSet(SetViewModel model)
        {
            if(model.SelectedSet == "defaultoption")
            {
                return RedirectToAction("Card");
            }
            //var card = await _service.GetRandomCardFromSet(model.SelectedSet);
            var card = await _dataWriterService.GetRandomCardBySet(model.SelectedSet);
            ViewBag.CardName = card.Name;
            ViewBag.CardSetName = card.SetName;
            ViewBag.ImageUrl = card.ImageUris.Large;
            return View(model);
        }

        [HttpPost]
        public IActionResult RedirectToCard()
        {
            return RedirectToAction("Card");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
