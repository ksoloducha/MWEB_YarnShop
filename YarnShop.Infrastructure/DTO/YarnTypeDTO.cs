using System;

namespace YarnShop.Infrastructure.DTO
{
    public class YarnTypeDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public double NeedlesSize { get; set; }
        public double price { get; set; }
        public ColorDTO Color { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as YarnTypeDTO;

            if (other != null)
            {
                return Id == other.Id
                    && Weight == other.Weight
                    && Length == other.Length
                    && NeedlesSize == other.NeedlesSize
                    && price == other.price
                    && Color.Equals(other.Color);
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Weight, Length, NeedlesSize, price, Color);
        }
    }
}
