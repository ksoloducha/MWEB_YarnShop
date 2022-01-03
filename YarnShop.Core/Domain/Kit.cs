using System.Collections.Generic;

namespace YarnShop.Core.Domain
{
    public class Kit
    {
        public int Id { get; set; }
        public Dictionary<YarnType, int> Yarns { get; set; }
        public CrochetHook Tool { get; set; }
        public string Pattern { get; set; }
    }
}
