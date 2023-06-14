using goods.Mappers.Abstract;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Models.ViewModels;
using ReviewApp.Services.Abstract;
using System.Linq;
using ReviewApp.Models.Dto;

namespace ReviewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoodsService _goodsService;
        private readonly ICommentsService _commentsService;
        
        public HomeController
        (
            ILogger<HomeController> logger,
            IGoodsService goodsService,
            ICommentsService commentsService
        )
        {
            _logger = logger;
            _goodsService = goodsService;
            _commentsService = commentsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel()
            {
                Goods = (await _goodsService.GetAllGoodsAsync())
                    .Select(g => new GoodViewModel() { Good = g })
                    .ToList()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddGood()
        {
            var model = new GoodViewModel()
            {
                Good = new GoodDto()
                {
                    Name = string.Empty,
                    Description = string.Empty
                }
            };
            
            return View(model);
        }
        
        [Route("Home/AddComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> AddComment(Guid id)
        {
            var good = await _goodsService.GetGoodByIdAsync(id);
            
            var model = new AddCommentViewModel()
            {
                GoodId = id,
                GoodName = good.Name,
                Comment = new CommentDto()
                {
                    Content = string.Empty,
                    Rating = 5
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentPost(AddCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddComment", model);
            }

            await _commentsService.AddCommentToGoodAsync(model.Comment, model.GoodId);
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddGoodPost(GoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddGood", model);
            }

            await _goodsService.AddGoodAsync(model.Good);
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> RemoveGood(Guid id)
        {
            await _goodsService.RemoveGoodAsync(id);
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
    }
}