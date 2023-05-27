using System.Collections.Generic;

namespace goods.Mappers.Abstract
{
    /// <summary>
    /// Goods mapper
    /// </summary>
    public interface IGoodsMapper
    {
        IReadOnlyCollection<ReviewApp.Models.ViewModels.GoodViewModel> Map(IEnumerable<DAO.Models.Good> goods);

        ReviewApp.Models.ViewModels.GoodViewModel Map(DAO.Models.Good good);

        DAO.Models.Good Map(ReviewApp.Models.ViewModels.GoodViewModel good);

        IReadOnlyCollection<DAO.Models.Good> Map(IEnumerable<ReviewApp.Models.ViewModels.GoodViewModel> goods);
    }
}
