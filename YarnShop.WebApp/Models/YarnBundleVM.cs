using YarnShop.Core.Domain;

namespace YarnShop.WebApp.Models
{
    public class YarnBundleVM
    {
        public int Id { get; set; }
        public YarnType YarnType { get; set; }
        public int n { get; set; }
        public double PricePercentage { get; set; }
    }
}
