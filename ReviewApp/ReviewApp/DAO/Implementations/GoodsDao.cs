using goods.DAO.Abstract;
using goods.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods.DAO.Implementations
{
    public class GoodsDao : IGoodsDao
    {
        private MainDbContext _mainDbContext;

        public GoodsDao()
        {
            _mainDbContext = new MainDbContext();
        }

        public async Task AddGoodAsync(Good good)
        {
            _ = good ?? throw new ArgumentNullException(nameof(good));

            _mainDbContext.Add(good);
            _mainDbContext.SaveChanges();
        }

        public async Task<IReadOnlyCollection<Good>> GetAllGoodsAsync()
        {
            return _mainDbContext
                .Goods
                .ToList();
        }
    }
}
