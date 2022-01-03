using System.Collections.Generic;
using YarnShop.Core.Domain;

namespace YarnShop.Infrastructure.DTO
{
    public class KitDTO
    {
        public int Id { get; set; }
        public Dictionary<YarnType, int> Yarns { get; set; }
        public CrochetHook Tool { get; set; }
        public string Pattern { get; set; }
    }
}
