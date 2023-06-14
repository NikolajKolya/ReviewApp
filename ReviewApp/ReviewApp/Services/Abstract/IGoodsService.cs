using ReviewApp.Models.Dto;
using ReviewApp.Models.ViewModels;

namespace ReviewApp.Services.Abstract;

public interface IGoodsService
{
    /// <summary>
    /// Add good to DB
    /// </summary>
    Task AddGoodAsync(GoodDto good);

    Task RemoveGoodAsync(Guid id);

    Task<IReadOnlyCollection<GoodDto>> GetAllGoodsAsync();

    Task<GoodDto> GetGoodByIdAsync(Guid id);
}