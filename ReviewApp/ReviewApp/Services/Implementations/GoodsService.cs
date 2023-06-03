﻿using goods.DAO.Abstract;
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
        await _goodsDao.AddGoodAsync(dbGood);
    }

    public async Task<IReadOnlyCollection<GoodViewModel>> GetAllGoodsAsync()
    {
        var dbGoods = await _goodsDao.GetAllGoodsAsync();

        return _goodsMapper.Map(dbGoods);
    }

    public async Task RemoveGoodAsync(GoodViewModel someGood)
    {
        _ = someGood ?? throw new ArgumentNullException(nameof(someGood));
        
        var dbGood = _goodsMapper.Map(someGood);
        await _goodsDao.RemoveGoodAsync(dbGood);
    }
}