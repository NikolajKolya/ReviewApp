using System;
using System.Collections.Generic;
using goods.DAO.Models;

namespace goods.DAO.Abstract
{
    public interface IGoodsDao
    {
        Task AddGoodAsync(Good good);

        Task RemoveGoodAsync(Guid id);

        Task<IReadOnlyCollection<Good>> GetAllGoodsAsync();

        Task<Good> GetGoodByIdAsync(Guid id);
    }
}
