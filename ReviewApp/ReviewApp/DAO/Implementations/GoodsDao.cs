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
        private readonly MainDbContext _mainDbContext;
        public GoodsDao(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task AddGoodAsync(Good good)
        {
            _ = good ?? throw new ArgumentNullException(nameof(good));

            _mainDbContext.Add(good);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Good>> GetAllGoodsAsync()
        {
            return _mainDbContext
                .Goods
                .OrderByDescending(b => b.TimeSpan)
                .ToList();
        }

        public async Task RemoveGoodAsync(Guid id)
        {

            var good = await GetGoodByIdAsync(id);
            _mainDbContext.Remove(good);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<Good> GetGoodByIdAsync(Guid id)
        {
            return _mainDbContext
                .Goods
                .Single(g => g.Id == id);
        }
    }
}
