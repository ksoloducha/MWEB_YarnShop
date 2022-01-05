using YarnShop.Core.Domain;

namespace YarnShop.Infrastructure.DTO
{
    public class YarnTypeDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public double NeedlesSize { get; set; }
        public double price { get; set; }
        public Color Color { get; set; }
    }
}
