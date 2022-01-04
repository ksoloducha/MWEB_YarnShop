namespace YarnShop.Core.Domain
{
    public class YarnType
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public double[] GaugeKnit { get; set; }
        public double NeedlesSize { get; set; }
        public double price { get; set; }
    }
}
