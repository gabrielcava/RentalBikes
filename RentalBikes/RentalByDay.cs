using System;
using System.Collections.Generic;
using System.Text;

namespace RentalBikes
{
    public class RentalByDay : RentalBase
    {
        private const int pricePerDay = 20;

        public double Days { get; set; }

        public override double CalculatePrice()
        {
            return pricePerDay * Days;
        }
    }
}
