using System;
using CrazyPassenger.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyPassenger.Tests
{
    [TestClass]
    public class PassengerTests
    {
        [TestMethod]
        public void IsSittingOnAllocatedSeatReturnsTrueWhenPassengerIsSittingOnAssignedSeat()
        {
            //arrange
            var passenger = new Passenger(1, 10);

            //act
            passenger.TakeSeat(10);

            //assert
            Assert.IsTrue(passenger.IsSittingOnAllocatedSeat);
        }

        [TestMethod]
        public void IsSittingOnAllocatedSeatReturnsFalseWhenPassengerIsNotSittingOnAssignedSeat()
        {
            //arrange
            var passenger = new Passenger(1, 10);

            //act
            passenger.TakeSeat(5);

            //assert
            Assert.IsFalse(passenger.IsSittingOnAllocatedSeat);
        }

        [TestMethod]
        public void CreatingPassengerWillSetPassengerId()
        {
            //arrange/act
            var passenger = new Passenger(1, 10);

            //assert
            Assert.AreEqual(1, passenger.Id);
        }

        [TestMethod]
        public void CreatingPassengerWillSetAssignedSeat()
        {
            //arrange/act
            var passenger = new Passenger(1, 10);

            //assert
            Assert.AreEqual(10, passenger.AssignedSeat);
        }

        [TestMethod]
        public void CreatingPassengerWillNotSetTakenSeat()
        {
            //arrange/act
            var passenger = new Passenger(1, 10);

            //assert
            Assert.AreEqual(0, passenger.SeatTaken);
        }

        [TestMethod]
        public void TakeSeatWillSetSeatTaken()
        {
            //arrange
            var passenger = new Passenger(1, 10);

            //act
            passenger.TakeSeat(9);

            //assert
            Assert.AreEqual(9, passenger.SeatTaken);
        }


    }
}
