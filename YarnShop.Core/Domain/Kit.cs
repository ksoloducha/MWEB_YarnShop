using System.Collections.Generic;

namespace YarnShop.Core.Domain
{
    public class Kit
    {
        public int Id { get; set; }
        public YarnType yarnType { get; set; }
        public int n { get; set; }
        public KnittingNeedle Tool { get; set; }
        public string Pattern { get; set; }
    }
}
