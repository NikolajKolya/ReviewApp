using goods.DAO.Models;
using System;
using System.Collections.Generic;

namespace goods.DAO.Abstract
{
    public interface IGoodsDao
    {
        Task AddGoodAsync(Good good);

        Task<IReadOnlyCollection<Good>> GetAllGoodsAsync();
    }
}
