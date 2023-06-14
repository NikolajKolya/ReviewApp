using goods.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewApp.Models.Dto;

namespace goods.Mappers.Implementations
{
    public class GoodsMapper : IGoodsMapper
    {
        public IReadOnlyCollection<GoodDto> Map(IEnumerable<DAO.Models.Good> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }

        public GoodDto Map(DAO.Models.Good good)
        {
            if (good == null)
            {
                return null;
            }

            return new GoodDto()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                TimeSpan = good.TimeSpan
            };
        }

        public DAO.Models.Good Map(GoodDto good)
        {
            if (good == null)
            {
                return null;
            }

            return new DAO.Models.Good()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                TimeSpan = good.TimeSpan
            };
        }

        public IReadOnlyCollection<DAO.Models.Good> Map(IEnumerable<GoodDto> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }
    }
}
