
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalBike;

namespace RentalBikesTests
{
    [TestClass]
    public class RentalTest
    {
        [TestMethod]
        public void Rental_CalculatePrice_RentalByHour_Succeeds()
        {
            //Arrange
            int pricePerHour = 5;
            decimal units = 3;
            Rental rental = new Rental(pricePerHour, units);

            //Act
            decimal totalPrice = rental.CalculatePrice();

            //Assert
            Assert.IsNotNull(totalPrice);
            Assert.AreEqual(pricePerHour * units, totalPrice);
        }

        [TestMethod]
        public void Rental_CalculatePrice_RentalByDay_Succeeds()
        {
            //Arrange
            int pricePerDay = 20;
            decimal units = 3;
            Rental rental = new Rental(pricePerDay, units);

            //Act
            decimal totalPrice = rental.CalculatePrice();

            //Assert
            Assert.IsNotNull(totalPrice);
            Assert.AreEqual(pricePerDay * units, totalPrice);
        }

        [TestMethod]
        public void Rental_CalculatePrice_RentalByWeek_Succeeds()
        {
            //Arrange
            int pricePerWeek = 60;
            decimal units = 1;
            Rental rental = new Rental(pricePerWeek, units);

            //Act
            decimal totalPrice = rental.CalculatePrice();

            //Assert
            Assert.IsNotNull(totalPrice);
            Assert.AreEqual(pricePerWeek * units, totalPrice);
        }
    }
}
