using goods.DAO.Abstract;
using goods.DAO.Models;

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
}