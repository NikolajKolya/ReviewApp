using ReviewApp.Models.Dto;

namespace ReviewApp.Services.Abstract;

public interface ICommentsService
{
    Task AddCommentToGoodAsync(CommentDto comment, Guid goodId);
}