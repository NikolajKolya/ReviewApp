using System.Collections.Generic;
using ReviewApp.Models.Dto;

namespace goods.Mappers.Abstract
{
    /// <summary>
    /// Goods mapper
    /// </summary>
    public interface IGoodsMapper
    {
        IReadOnlyCollection<GoodDto> Map(IEnumerable<DAO.Models.Good> goods);

        GoodDto Map(DAO.Models.Good good);

        DAO.Models.Good Map(GoodDto good);

        IReadOnlyCollection<DAO.Models.Good> Map(IEnumerable<GoodDto> goods);
    }
}
