using Microsoft.AspNetCore.Mvc;
using ReviewApp.Models.ViewModels;

namespace ReviewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddGood()
        {
            var model = new GoodViewModel()
            {
                Name = string.Empty,
                Description = string.Empty
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGoodPost(GoodViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddGood", viewModel);
            }
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}