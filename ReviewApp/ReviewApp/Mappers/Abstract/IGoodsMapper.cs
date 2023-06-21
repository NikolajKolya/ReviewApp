using ReviewApp.DAO.Models;
using ReviewApp.Models.Dto;

namespace ReviewApp.Mappers.Abstract
{
    /// <summary>
    /// Goods mapper
    /// </summary>
    public interface IGoodsMapper
    {
        IReadOnlyCollection<GoodDto> Map(IEnumerable<Good> goods);

        GoodDto Map(Good good);

        Good Map(GoodDto good);

        IReadOnlyCollection<Good> Map(IEnumerable<GoodDto> goods);
    }
}
