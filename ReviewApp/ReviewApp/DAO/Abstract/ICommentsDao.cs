using ReviewApp.DAO.Models;

namespace ReviewApp.DAO.Abstract;

public interface ICommentsDao
{
    Task AddCommentAsync(Comment comment);
    
    Task<List<Comment>> GetAllCommentsAsync(Guid goodId);
    
    Task<Comment> GetLastCommentsAsync(Guid goodId);
}