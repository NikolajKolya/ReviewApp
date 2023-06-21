using ReviewApp.DAO.Models;
using ReviewApp.Mappers.Abstract;
using ReviewApp.Models.Dto;

namespace ReviewApp.Mappers.Implementations
{
    public class GoodsMapper : IGoodsMapper
    {
        public IReadOnlyCollection<GoodDto> Map(IEnumerable<Good> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }

        public GoodDto Map(Good good)
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
                TimeSpan = good.TimeSpan,
                PhotoFileId = good.PhotoFileId
            };
        }

        public Good Map(GoodDto good)
        {
            if (good == null)
            {
                return null;
            }

            return new Good()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                TimeSpan = good.TimeSpan,
                PhotoFileId = good.PhotoFileId
            };
        }

        public IReadOnlyCollection<Good> Map(IEnumerable<GoodDto> goods)
        {
            if (goods == null)
            {
                return null;
            }

            return goods.Select(n => Map(n)).ToList();
        }
    }
}
