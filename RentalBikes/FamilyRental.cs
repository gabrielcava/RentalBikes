using System;
using System.Collections.Generic;
using System.Text;

namespace RentalBikes
{
    public class FamilyRental : RentalBase
    {
        private IList<RentalBase> rentalList;

        private decimal discount;

        public FamilyRental(decimal discount)
        {
            this.discount = discount;
            rentalList = new List<RentalBase>();
        }

        public void AddRental(RentalBase rental)
        {
            if (rentalList.Count < 5)
            {
                rentalList.Add(rental);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRental(RentalBase rental)
        {
            if (rentalList.Count > 0)
            {
                rentalList.Remove(rental);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public RentalBase GetRental(int index)
        {
            if (index >= 0 && index <= 4)
            {
                return rentalList[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override decimal CalculatePrice()
        {
            decimal totalPrice = 0;
            foreach (var rental in rentalList)
            {
                totalPrice += rental.CalculatePrice();
            }

            return totalPrice * discount;
        }
    }
}
