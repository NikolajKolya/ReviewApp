using goods.DAO.Abstract;
using goods.DAO.Models;
using ReviewApp.Views.Home;

namespace goods.DAO.Implementations;

public class CommentsDao : ICommentsDao
{
    private readonly MainDbContext _mainDbContext;
    
    public CommentsDao(MainDbContext mainDbContext)
    {
        _mainDbContext = mainDbContext;
    }
    
    public async Task AddCommentAsync(Comment comment)
    {
        _ = comment ?? throw new ArgumentNullException(nameof(comment));

        _mainDbContext.Add(comment);
        await _mainDbContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllCommentsAsync(Guid goodId)
    {
        return _mainDbContext
            .Comments
            .Where(c => c.Good.Id == goodId)
            .ToList();
    }
}