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
            _mainDbContext.SaveChanges();
        }

        public async Task<IReadOnlyCollection<Good>> GetAllGoodsAsync()
        {
            return _mainDbContext
                .Goods
                .ToList();
        }

        public async Task RemoveGoodAsync(Guid Id)
        {

            var taskGood = GetGoodById(Id);
            var good = new Good
            {
                Id = taskGood.Id,
                Name = taskGood.Name,
                Description = taskGood.Description
            };
            _mainDbContext.Remove(good);
            _mainDbContext.SaveChanges();
        }

        public Good GetGoodById(Guid Id)
        {
            return _mainDbContext
                .Goods
                .Single(g => g.Id == Id);
        }
    }
}
