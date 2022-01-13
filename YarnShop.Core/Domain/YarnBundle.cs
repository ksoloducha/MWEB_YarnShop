using System;

namespace YarnShop.Core.Domain
{
    public class YarnBundle
    {
        public int Id { get; set; }
        public YarnType YarnType { get; set; }
        public int n { get; set; }
        public double PricePercentage { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as YarnBundle;

            if(other != null)
            {
                return Id == other.Id
                    && YarnType.Equals(other.YarnType)
                    && n == other.n
                    && PricePercentage == other.PricePercentage;
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, YarnType, n, PricePercentage);
        }
    }
}
