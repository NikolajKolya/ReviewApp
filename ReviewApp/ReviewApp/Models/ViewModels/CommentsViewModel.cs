using ReviewApp.Models.Dto;

namespace ReviewApp.Models.ViewModels;

public class CommentsViewModel
{
    public IReadOnlyCollection<CommentDto> Comments { get; set; }
}