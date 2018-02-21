using System;
using System.Collections.Generic;
using System.Text;

namespace RentalBikes
{
    public class RentalByHour : RentalBase
    {
        private const int pricePerHour = 5;

        public double Hours { get; set; }

        public override double CalculatePrice()
        {
            return pricePerHour * Hours;
        }
    }
}
