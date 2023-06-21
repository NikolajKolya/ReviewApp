using ReviewApp.DAO.Abstract;
using ReviewApp.Mappers.Abstract;
using ReviewApp.Models.Dto;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class CommentsService : ICommentsService
{
    private readonly IGoodsDao _goodsDao;
    private readonly ICommentsDao _commentsDao;
    private readonly ICommentsMapper _commentsMapper;


    public CommentsService(IGoodsDao goodsDao, ICommentsDao commentsDao, ICommentsMapper commentsMapper)
    {
        _goodsDao = goodsDao;
        _commentsMapper = commentsMapper;
        _commentsDao = commentsDao;
    }
    
    public async Task AddCommentToGoodAsync(CommentDto comment, Guid goodId)
    {
        _ = comment ?? throw new ArgumentException(nameof(comment));
        
        var good = await _goodsDao.GetGoodByIdAsync(goodId);

        _ = good ?? throw new ArgumentException(nameof(goodId));

        var commentDb = _commentsMapper.Map(comment);
        commentDb.Good = good;
        
        await _commentsDao.AddCommentAsync(commentDb);
    }

    public async Task<IReadOnlyCollection<CommentDto>> GetAllCommentsAsync(Guid goodId)
    {
        return _commentsMapper.Map(await _commentsDao.GetAllCommentsAsync(goodId));
    }

    public async Task<CommentDto> GetLastCommentsAsync(Guid goodId)
    {
        return _commentsMapper.Map(await _commentsDao.GetLastCommentsAsync(goodId));
    }
}