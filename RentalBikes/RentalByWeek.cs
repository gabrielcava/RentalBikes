using System;
using System.Collections.Generic;
using System.Text;

namespace RentalBikes
{
    public class RentalByWeek : RentalBase
    {
        private const int pricePerWeek = 20;

        public double Weeks { get; set; }

        public override double CalculatePrice()
        {
            return pricePerWeek * Weeks;
        }
    }
}
