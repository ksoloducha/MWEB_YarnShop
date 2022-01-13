using System;

namespace YarnShop.Infrastructure.DTO
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int n { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ColorDTO;

            if (other != null)
            {
                return Id == other.Id
                    && Name == other.Name
                    && n == other.n;
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, n);
        }
    }
}
