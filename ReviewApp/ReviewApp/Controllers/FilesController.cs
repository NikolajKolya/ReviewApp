using System.Text;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Controllers;

public class FilesController : Controller
{
    private readonly IGoodsService _goodsService;
    private readonly IFilesService _filesService;

    public FilesController
    (
        IGoodsService goodsService,
        IFilesService filesService
    )
    {
        _goodsService = goodsService;
        _filesService = filesService;
    }
    
    /// <summary>
    /// Download a file
    /// </summary>
    [HttpGet]
    [Route("Files/GoodImage/{goodId}")]
    public async Task<IActionResult> Download(Guid goodId)
    {
        var good = await _goodsService.GetGoodByIdAsync(goodId);
        var goodPhoto = await _filesService.GetFileByIdAsync(good.PhotoFileId);

        return File(goodPhoto.Item2, goodPhoto.Item1);
    }
}