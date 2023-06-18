using ReviewApp.Models.Dto;

namespace ReviewApp.Models.ViewModels;

public class CommentsViewModel
{
    public GoodDto Good { get; set; }

    public IReadOnlyCollection<CommentDto> Comments { get; set; }
}