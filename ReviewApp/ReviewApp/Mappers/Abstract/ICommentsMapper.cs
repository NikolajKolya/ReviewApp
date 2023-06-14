using goods.DAO.Models;
using ReviewApp.Models.Dto;

namespace goods.Mappers.Abstract;

public interface ICommentsMapper
{
    IReadOnlyCollection<CommentDto> Map(IEnumerable<Comment> comments);

    CommentDto Map(Comment comment);

    Comment Map(CommentDto comment);

    IReadOnlyCollection<Comment> Map(IEnumerable<CommentDto> comments);
}