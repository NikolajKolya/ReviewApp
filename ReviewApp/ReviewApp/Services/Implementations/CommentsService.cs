using ReviewApp.DAO.Abstract;
using ReviewApp.Mappers.Abstract;
using ReviewApp.Models.Dto;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class CommentsService : ICommentsService
{
    private readonly IGoodsDao _goodsDao;
    private readonly ICommentsMapper _commentsMapper;


    public CommentsService(IGoodsDao goodsDao, ICommentsMapper commentsMapper)
    {
        _goodsDao = goodsDao;
        _commentsMapper = commentsMapper;
    }
    
    public async Task AddCommentToGoodAsync(CommentDto comment, Guid goodId)
    {
        _ = comment ?? throw new ArgumentException(nameof(comment));
        
        var good = await _goodsDao.GetGoodByIdAsync(goodId);

        _ = good ?? throw new ArgumentException(nameof(goodId));

        var commentDb = _commentsMapper.Map(comment);

        await _goodsDao.AddCommentToGoodAsync(good, commentDb);
    }

    public async Task<IReadOnlyCollection<CommentDto>> GetAllCommentsAsync(Guid goodId)
    {
        return _commentsMapper.Map((await _goodsDao.GetGoodByIdAsync(goodId)).Comments);
    }

    public async Task<CommentDto> GetLastCommentsAsync(Guid goodId)
    {
        var lastComment = (await _goodsDao.GetGoodByIdAsync(goodId))
            .Comments
            .MaxBy(c => c.CreationTime);
        
        return _commentsMapper.Map(lastComment);
    }
}