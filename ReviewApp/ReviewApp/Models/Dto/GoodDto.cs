using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models.Dto;

public class GoodDto
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Id")]
    public Guid Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Название")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Описание")]
    public string Description { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Время")]
    public DateTime TimeSpan { get; set; }
}