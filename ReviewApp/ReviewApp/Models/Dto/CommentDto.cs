using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models.Dto;

public class CommentDto
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Id")]
    public Guid Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Комментарий")]
    public string Content { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Оценка")]
    public int Rating { get; set; }
    
    [DataType(DataType.DateTime)]
    [Display(Name = "Время")]
    public DateTime CreationTime { get; set; }
}