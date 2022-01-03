namespace YarnShop.Infrastructure.DTO
{
    internal class YarnTypeDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public double[] GaugeKnitting { get; set; }
        public double[] GaugeCrochet { get; set; }
        public double NeedlesSize { get; set; }
        public double price { get; set; }
    }
}
