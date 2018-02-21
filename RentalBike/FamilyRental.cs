using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalBike
{
    public class FamilyRental : RentalBase
    {
        private IList<RentalBase> rentalList;

        private decimal discount;

        public FamilyRental(decimal discount)
        {
            if (discount > 1 || discount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
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
            if (index >= 0 && index < rentalList.Count)
            {
                return rentalList[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetRentalCount()
        {
            return rentalList.Count;
        }

        public override decimal CalculatePrice()
        {
            if (rentalList.Count > 2)
            {
                decimal totalPrice = 0;
                foreach (var rental in rentalList)
                {
                    totalPrice += rental.CalculatePrice();
                }

                return totalPrice * (1 - discount);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
