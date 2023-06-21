using ReviewApp.DAO.Abstract;
using ReviewApp.Mappers.Abstract;
using ReviewApp.Models.Dto;
using ReviewApp.Models.ViewModels;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class GoodsService : IGoodsService
{
    private readonly IGoodsMapper _goodsMapper;
    private readonly IGoodsDao _goodsDao;
    private readonly IFilesService _filesService;

    public GoodsService
    (
        IGoodsMapper goodsMapper,
        IGoodsDao goodsDao,
        IFilesService filesService
    )
    {
        _goodsMapper = goodsMapper;
        _goodsDao = goodsDao;
        _filesService = filesService;
    }
    
    public async Task AddGoodAsync(GoodDto good, IFormFile photo)
    {
        _ = good ?? throw new ArgumentNullException(nameof(good));

        var dbGood = _goodsMapper.Map(good);
        dbGood.TimeSpan = DateTime.UtcNow;
        
        // Сначала добавляем файл в базу
        var fileId = await _filesService.AddFileAsync
                (
                    photo.ContentType,
                    await _filesService.FileToBytesArrayAsync(photo)
                );

        dbGood.PhotoFileId = fileId;
        
        await _goodsDao.AddGoodAsync(dbGood);
    }

    public async Task<IReadOnlyCollection<GoodDto>> GetAllGoodsAsync()
    {
        var dbGoods = await _goodsDao.GetAllGoodsAsync();

        return _goodsMapper.Map(dbGoods);
    }

    public async Task<GoodDto> GetGoodByIdAsync(Guid id)
    {
        return _goodsMapper.Map(await _goodsDao.GetGoodByIdAsync(id));
    }

    public async Task RemoveGoodAsync(Guid id)
    {
        await _goodsDao.RemoveGoodAsync(id);
    }
}