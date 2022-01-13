﻿using System;

namespace YarnShop.Core.Domain
{
    public class KnittingNeedle
    {
        public int Id { get; set; }
        public double Size { get; set; }
        public int n { get; set; }
        public bool Circular { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as KnittingNeedle;

            if (other != null)
            {
                return Id == other.Id 
                    && Size == other.Size 
                    && n == other.n
                    && Circular == other.Circular;
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Size, n, Circular);
        }
    }
}
