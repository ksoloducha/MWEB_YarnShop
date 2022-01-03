using YarnShop.Core.Domain;

namespace YarnShop.Infrastructure.DTO
{
    public class YarnBundleDTO
    {
        public int Id { get; set; }
        public YarnType YarnType { get; set; }
        public int n { get; set; }
        public double PricePercentage { get; set; }
    }
}
