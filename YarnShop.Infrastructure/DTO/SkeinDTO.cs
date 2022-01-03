﻿using System.Collections.Generic;
using YarnShop.Core.Domain;

namespace YarnShop.Infrastructure.DTO
{
    internal class SkeinDTO
    {
        public int Id { get; set; }
        public YarnType YarnType { get; set; }
        public Dictionary<Color, int> AvailableColors { get; set; }
    }
}
