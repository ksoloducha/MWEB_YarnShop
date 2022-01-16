using YarnShop.Core.Domain;

namespace YarnShop.WebApp.Models
{
    public class KitVM
    {
        public int Id { get; set; }
        public YarnType yarnType { get; set; }
        public int n { get; set; }
        public KnittingNeedle Tool { get; set; }
        public string Pattern { get; set; }
    }
}
