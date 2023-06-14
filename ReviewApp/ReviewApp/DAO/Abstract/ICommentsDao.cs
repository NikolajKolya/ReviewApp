using goods.DAO.Models;
using ReviewApp.Migrations;

namespace goods.DAO.Abstract;

public interface ICommentsDao
{
    Task AddCommentAsync(Comment comment);
}