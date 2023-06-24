using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models.ViewModels.AccountViewModels;

public class RegisterViewModel
{
    [Required]
    [StringLength(32, ErrorMessage = "Поле {0} должно быть как минимум {2} и как максимум {1} символов в длину.", MinimumLength = 8)]
    [DataType(DataType.Text)]
    [Display(Name = "Логин")]
    public string Login { get; set; }

    [Required]
    [StringLength(32, ErrorMessage = "Поле {0} должно быть как минимум {2} и как максимум {1} символов в длину.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Повторите пароль")]
    [Compare("Password", ErrorMessage = "Пароль и подтверждение не совпадают!")]
    public string ConfirmPassword { get; set; }
}