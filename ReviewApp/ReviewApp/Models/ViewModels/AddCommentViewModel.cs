using ReviewApp.Models.Dto;

namespace ReviewApp.Models.ViewModels;

public class AddCommentViewModel
{
    /// <summary>
    /// К какому товару мы добавляем комментарий (ID)
    /// </summary>
    public Guid GoodId { get; set; }

    /// <summary>
    /// Товар, к которому мы оставляем комментарий
    /// </summary>
    public string GoodName { get; set; }

    /// <summary>
    /// Собственно комментарий
    /// </summary>
    public CommentDto Comment { get; set; }
}