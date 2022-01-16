using System.ComponentModel.DataAnnotations;
using YarnShop.Core.Domain;

namespace YarnShop.WebApp.Models
{
    public class YarnTypeVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public double NeedlesSize { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public Color Color { get; set; }
    }
}
