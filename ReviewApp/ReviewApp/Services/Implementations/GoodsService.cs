using goods.DAO.Abstract;
using goods.DAO.Models;
using goods.Mappers.Abstract;
using ReviewApp.Models.ViewModels;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class GoodsService : IGoodsService
{
    private readonly IGoodsMapper _goodsMapper;
    private readonly IGoodsDao _goodsDao;

    public GoodsService
    (
        IGoodsMapper goodsMapper,
        IGoodsDao goodsDao
    )
    {
        _goodsMapper = goodsMapper;
        _goodsDao = goodsDao;
    }
    
    public async Task AddGoodAsync(GoodViewModel good)
    {
        _ = good ?? throw new ArgumentNullException(nameof(good));

        var dbGood = _goodsMapper.Map(good);
        dbGood.TimeSpan = DateTime.UtcNow;
        await _goodsDao.AddGoodAsync(dbGood);
    }

    public async Task<IReadOnlyCollection<GoodViewModel>> GetAllGoodsAsync()
    {
        var dbGoods = await _goodsDao.GetAllGoodsAsync();

        return _goodsMapper.Map(dbGoods);
    }

    public async Task<GoodViewModel> GetGoodByIdAsync(Guid id)
    {
        return _goodsMapper.Map(await _goodsDao.GetGoodByIdAsync(id));
    }

    public async Task RemoveGoodAsync(Guid id)
    {
        await _goodsDao.RemoveGoodAsync(id);
    }
}