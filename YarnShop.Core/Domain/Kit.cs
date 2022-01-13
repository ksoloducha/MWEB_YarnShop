using System;

namespace YarnShop.Core.Domain
{
    public class Kit
    {
        public int Id { get; set; }
        public YarnType yarnType { get; set; }
        public int n { get; set; }
        public KnittingNeedle Tool { get; set; }
        public string Pattern { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Kit;

            if(other != null)
            {
                return Id == other.Id
                    && yarnType.Equals(other.yarnType)
                    && n == other.n
                    && Tool.Equals(other.Tool)
                    && Pattern == other.Pattern;
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, yarnType, n, Tool, Pattern);
        }
    }
}
