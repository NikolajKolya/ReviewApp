using System.ComponentModel.DataAnnotations;
using ReviewApp.Models.Dto;

namespace ReviewApp.Models.ViewModels;

public class GoodViewModel
{
    public GoodDto Good { get; set; }
    public CommentDto LastComment { get; set; }
}