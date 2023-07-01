using Microsoft.EntityFrameworkCore;
using ReviewApp.DAO.Abstract;
using ReviewApp.DAO.Models;

namespace ReviewApp.DAO.Implementations
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
                .Include(g => g.Comments)
                .OrderByDescending(b => b.TimeSpan)
                .ToList();
        }

        public async Task RemoveGoodAsync(Guid id)
        {
            var good = await GetGoodByIdAsync(id);

            _mainDbContext.Comments.RemoveRange(good.Comments);
            _mainDbContext.Remove(good);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<Good> GetGoodByIdAsync(Guid id)
        {
            return await _mainDbContext
                .Goods
                .Include(g => g.Comments)
                .SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddCommentToGoodAsync(Good good, Comment comment)
        {
            comment.Good = good;
            comment.CreationTime = DateTime.UtcNow;
            good.Comments.Add(comment);
            await _mainDbContext.SaveChangesAsync();
        }
    }
}
