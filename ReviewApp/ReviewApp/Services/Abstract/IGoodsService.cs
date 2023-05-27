using ReviewApp.Models.ViewModels;

namespace ReviewApp.Services.Abstract;

public interface IGoodsService
{
    /// <summary>
    /// Add good to DB
    /// </summary>
    Task AddGoodAsync(GoodViewModel good);

    Task<IReadOnlyCollection<GoodViewModel>> GetAllGoodsAsync();
}