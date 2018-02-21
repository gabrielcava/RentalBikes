using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalBike
{
    public class Rental : RentalBase
    {
        private int pricePerUnit;

        private decimal units;

        public Rental(int pricePerUnit, decimal units)
        {
            this.pricePerUnit = pricePerUnit;
            this.units = units;
        }

        public override decimal CalculatePrice()
        {
            return pricePerUnit * units;
        }
    }
}
