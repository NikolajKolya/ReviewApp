using goods.Mappers.Abstract;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Models.ViewModels;
using ReviewApp.Services.Abstract;
using System.Linq;

namespace ReviewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoodsService _goodsService;
        
        public HomeController
        (
            ILogger<HomeController> logger,
            IGoodsService goodsService
        )
        {
            _logger = logger;
            _goodsService = goodsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel()
            {
                Goods = (await _goodsService.GetAllGoodsAsync()).ToList()
            };
            return View(model);
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

            await _goodsService.AddGoodAsync(viewModel);
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}