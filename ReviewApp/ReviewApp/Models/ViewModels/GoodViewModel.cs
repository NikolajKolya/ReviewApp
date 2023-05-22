using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models.ViewModels;

public class GoodViewModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Название")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Описание")]
    public string Description { get; set; }
}