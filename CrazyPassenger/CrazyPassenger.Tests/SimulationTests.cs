using System;
using System.Collections.Generic;
using System.Linq;
using CrazyPassenger.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CrazyPassenger.Tests
{
    [TestClass]
    public class SimulationTests
    {
        [TestMethod]
        public void CallingSetupCreatesPassengers()
        {
            //arrange
            var seats = 100;
            var mockPlaneFactory = new Mock<IAirPlaneFactory>();
            var mock = new Mock<Simulation>(MockBehavior.Strict, new object[] { seats, mockPlaneFactory.Object }) { CallBase = true };
            bool called = false;
            mock.Setup(x => x.CreatePassengers()).Callback(() => { called = true; });
            
            //act
            mock.Object.Setup();

            //assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void CallingRunWillCreateAirPlaneUsingAirPlaneFactory()
        {
            //arrange
            var mockplane = new Mock<IAirPlane>();
            var mockPlaneFactory = new Mock<IAirPlaneFactory>();
            mockPlaneFactory.Setup(x => x.CreateAirPlane(It.IsAny<List<Passenger>>())).Returns(mockplane.Object);
            var simulation = new Mock<Simulation>(MockBehavior.Strict, new object[] { 100, mockPlaneFactory.Object }) { CallBase = true };
            simulation.Object.Passengers.Add(new Passenger(1, 1));

            //act
            simulation.Object.Run();

            //assert
            mockPlaneFactory.Verify(x => x.CreateAirPlane(It.IsAny<List<Passenger>>()), Times.Once);
        }

        [TestMethod]
        public void CallingRunWillBoardPassengersOnAirPlane()
        {
            //arrange
            var mockplane = new Mock<IAirPlane>();
            var mockPlaneFactory = new Mock<IAirPlaneFactory>();
            mockPlaneFactory.Setup(x => x.CreateAirPlane(It.IsAny<List<Passenger>>())).Returns(mockplane.Object);
            var simulation = new Mock<Simulation>(MockBehavior.Strict, new object[] { 100, mockPlaneFactory.Object }) { CallBase = true };
            simulation.Object.Passengers.Add(new Passenger(1, 1));

            //act
            simulation.Object.Run();

            //assert
            mockplane.Verify(x => x.BoardPassengers(), Times.Once);
        }

        [TestMethod]
        public void CallingRunReturns_True_IfLastPassengerGetsAssignedSeat()
        {
            //arrange
            var mockplane = new Mock<IAirPlane>();
            var mockPlaneFactory = new Mock<IAirPlaneFactory>();
            mockPlaneFactory.Setup(x => x.CreateAirPlane(It.IsAny<List<Passenger>>())).Returns(mockplane.Object);
            var simulation = new Mock<Simulation>(MockBehavior.Strict, new object[] { 100, mockPlaneFactory.Object }) { CallBase = true };
            
            var passenger = new Passenger(1, 1);
            passenger.TakeSeat(1);

            simulation.Object.Passengers.Add(passenger);

            //act
            var result = simulation.Object.Run();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CallingRunReturns_False_IfLastPassengerGetsAssignedSeat()
        {
            //arrange
            var mockplane = new Mock<IAirPlane>();
            var mockPlaneFactory = new Mock<IAirPlaneFactory>();
            mockPlaneFactory.Setup(x => x.CreateAirPlane(It.IsAny<List<Passenger>>())).Returns(mockplane.Object);
            var simulation = new Mock<Simulation>(MockBehavior.Strict, new object[] { 100, mockPlaneFactory.Object }) { CallBase = true };
            
            var passenger = new Passenger(1, 1);
            passenger.TakeSeat(2);

            simulation.Object.Passengers.Add(passenger);

            //act
            var result = simulation.Object.Run();

            //assert
            Assert.IsFalse(result);
        }

    }
}
