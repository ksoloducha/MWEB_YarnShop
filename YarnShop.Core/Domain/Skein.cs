using System.Collections.Generic;

namespace YarnShop.Core.Domain
{
    public class Skein
    {
        public int Id { get; set; }
        public YarnType YarnType { get; set; }
        public Dictionary<Color, int> AvailableColors { get; set; }

    }
}
