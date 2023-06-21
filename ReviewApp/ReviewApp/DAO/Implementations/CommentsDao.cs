using Microsoft.EntityFrameworkCore;
using ReviewApp.DAO.Abstract;
using ReviewApp.DAO.Models;

namespace ReviewApp.DAO.Implementations;

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
        
        comment.CreationTime = DateTime.UtcNow;
        _mainDbContext.Add(comment);
        await _mainDbContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllCommentsAsync(Guid goodId)
    {
        return _mainDbContext
            .Comments
            .Where(c => c.Good.Id == goodId)
            .OrderByDescending(c => c.CreationTime)
            .ToList();
    }

    public async Task<Comment> GetLastCommentsAsync(Guid goodId)
    {
         return await _mainDbContext
            .Comments
            .Where(c => c.Good.Id == goodId)
            .OrderByDescending(c => c.CreationTime)
            .FirstOrDefaultAsync();
    }
}