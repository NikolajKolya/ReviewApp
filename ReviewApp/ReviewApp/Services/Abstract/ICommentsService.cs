using goods.DAO.Models;
using ReviewApp.Models.Dto;

namespace ReviewApp.Services.Abstract;

public interface ICommentsService
{
    Task AddCommentToGoodAsync(CommentDto comment, Guid goodId);
    
    Task<IReadOnlyCollection<CommentDto>> GetAllCommentsAsync( Guid goodId);
}