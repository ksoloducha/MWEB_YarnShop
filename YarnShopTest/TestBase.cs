using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShopTest
{
    [TestClass]
    public class TestBase
    {
        protected readonly Mock<IColorsRepository> _mockedColorsRepository;
        protected readonly ColorsService _colorsService;

        public TestBase()
        {
            _mockedColorsRepository = new Mock<IColorsRepository>();
            _colorsService = new ColorsService(_mockedColorsRepository.Object);
        }

        protected Color ColorBase()
        {
            return new Color()
            {
                Id = 1,
                Name = "red",
                n = 5
            };
        }

        protected ColorDTO ColorDtoBase()
        {
            Color color = ColorBase();
            return new ColorDTO()
            {
                Id = color.Id,
                Name = color.Name,
                n = color.n
            };
        }
    }
}
