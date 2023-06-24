namespace ReviewApp.Services.Abstract;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public interface IAccountsService
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    Task<bool> RegisterUserAsync(string login, string email, string password);

    /// <summary>
    /// Вход на сайт
    /// </summary>
    Task<bool> LogInAsync(string login, string password);
}