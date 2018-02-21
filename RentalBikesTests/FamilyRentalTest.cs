using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalBike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalBikesTests
{
    [TestClass]
    public class FamilyRentalTest
    {
        #region Constructor Tests

        [TestMethod]
        public void FamilyRental_Constructor_DiscountInRange_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.10);

            //Act
            FamilyRental familyRental = new FamilyRental(discount);

            //Assert
            Assert.IsNotNull(familyRental);
        }

        [TestMethod]
        public void FamilyRental_Constructor_DiscountOutOfRange_Fail()
        {
            //Arrange
            decimal discount = new decimal(20);

            //Act && Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FamilyRental(discount));
        }

        [TestMethod]
        public void FamilyRental_Constructor_NegativeDiscount_Fail()
        {
            //Arrange
            decimal discount = new decimal(-10);

            //Act && Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FamilyRental(discount));
        }

        #endregion

        #region AddRental Tests

        [TestMethod]
        public void FamilyRental_AddRental_RentalListNotFull_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            //Act
            familyRental.AddRental(rental);

            //Assert
            Assert.AreEqual(1, familyRental.GetRentalCount());
        }

        [TestMethod]
        public void FamilyRental_AddRental_RentalListFull_Fails()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rental);
            familyRental.AddRental(rental);
            familyRental.AddRental(rental);
            familyRental.AddRental(rental);
            familyRental.AddRental(rental);

            //Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => familyRental.AddRental(rental));
        }

        #endregion

        #region RemoveRental Tests

        [TestMethod]
        public void FamilyRental_RemoveRental_RentalListNotEmpty_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rental);

            //Act
            familyRental.RemoveRental(rental);

            //Assert
            Assert.AreEqual(0, familyRental.GetRentalCount());
        }

        [TestMethod]
        public void FamilyRental_RemoveRental_RentalListEmpty_Fials()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            //Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => familyRental.RemoveRental(rental));
        }

        #endregion

        #region GetRental Tests

        [TestMethod]
        public void FamilyRental_GetRental_indexInRange_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rental);

            //Act
            var result = familyRental.GetRental(0);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(rental, result);
        }

        [TestMethod]
        public void FamilyRental_GetRental_indexOutOfRange_Fails()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rental);

            //Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => familyRental.GetRental(1));
        }

        #endregion

        #region GetRentalCount Tests

        [TestMethod]
        public void FamilyRental_GetRentalCount_AllParameters_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            int pricePerUnit = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerUnit, units);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rental);

            //Act
            var result = familyRental.GetRentalCount();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        #endregion

        #region CalculatePrice Tests

        [TestMethod]
        public void FamilyRental_CalculatePrice_RentalListFull_Succeeds()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            Rental rentalByHour = new Rental(5, 3);
            Rental rentalByDay = new Rental(20, 2);
            Rental rentalByWeek = new Rental(60, 1);
            FamilyRental familyRental = new FamilyRental(discount);
            FamilyRental familyRental2 = new FamilyRental(discount);

            familyRental2.AddRental(rentalByHour);
            familyRental2.AddRental(rentalByDay);
            familyRental2.AddRental(rentalByWeek);

            familyRental.AddRental(rentalByHour);
            familyRental.AddRental(rentalByDay);
            familyRental.AddRental(rentalByWeek);
            familyRental.AddRental(familyRental2);

            //Act
            var result = familyRental.CalculatePrice();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(136.85, (double)result);
        }

        [TestMethod]
        public void FamilyRental_CalculatePrice_RentalListNotFull_Fails()
        {
            //Arrange
            decimal discount = new decimal(0.30);
            Rental rentalByHour = new Rental(5, 3);
            Rental rentalByDay = new Rental(20, 2);
            Rental rentalByWeek = new Rental(60, 1);
            FamilyRental familyRental = new FamilyRental(discount);

            familyRental.AddRental(rentalByHour);
            familyRental.AddRental(rentalByDay);

            //Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => familyRental.CalculatePrice());
        }

        #endregion
    }
}
