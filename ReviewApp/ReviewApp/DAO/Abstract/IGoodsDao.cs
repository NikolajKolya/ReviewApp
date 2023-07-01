using ReviewApp.DAO.Models;

namespace ReviewApp.DAO.Abstract
{
    public interface IGoodsDao
    {
        Task AddGoodAsync(Good good);

        Task RemoveGoodAsync(Guid id);

        Task<IReadOnlyCollection<Good>> GetAllGoodsAsync();

        Task<Good> GetGoodByIdAsync(Guid id);

        Task AddCommentToGoodAsync(Good good, Comment comment);
    }
}
