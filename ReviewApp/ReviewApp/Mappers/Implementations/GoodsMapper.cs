using goods.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods.Mappers.Implementations
{
    public class GoodsMapper : IGoodsMapper
    {
        public IReadOnlyCollection<ReviewApp.Models.ViewModels.GoodViewModel> Map(IEnumerable<DAO.Models.Good> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }

        public ReviewApp.Models.ViewModels.GoodViewModel Map(DAO.Models.Good good)
        {
            if (good == null)
            {
                return null;
            }

            return new ReviewApp.Models.ViewModels.GoodViewModel()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description
            };
        }

        public DAO.Models.Good Map(ReviewApp.Models.ViewModels.GoodViewModel good)
        {
            if (good == null)
            {
                return null;
            }

            return new DAO.Models.Good()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description
            };
        }

        public IReadOnlyCollection<DAO.Models.Good> Map(IEnumerable<ReviewApp.Models.ViewModels.GoodViewModel> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }
    }
}
