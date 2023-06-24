using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models.ViewModels.AccountViewModels;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Логин")]
    public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}