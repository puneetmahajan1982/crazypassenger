using System;
using System.Collections.Generic;
using CrazyPassenger.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyPassenger.Tests
{
    [TestClass]
    public class AirPlaneFactoryTests
    {
        [TestMethod]
        public void AirFactoryCreatesAirPlane()
        {
            //arrange
            var airplaneFactory = new AirPlaneFactory();
            var passengers = new List<Passenger>()
            {
                new Passenger(1, 1),
                new Passenger(2, 2),
            };

            //act
            var result = airplaneFactory.CreateAirPlane(passengers);

            //assert
            Assert.IsInstanceOfType(result, typeof(IAirPlane));
        }

        [TestMethod]
        public void AirFactoryCreatesAirPlaneWithAllPassengers()
        {
            //arrange
            var airplaneFactory = new AirPlaneFactory();
            var passengers = new List<Passenger>()
            {
                new Passenger(1, 1),
                new Passenger(2, 2),
            };

            //act
            var result = airplaneFactory.CreateAirPlane(passengers);

            //assert
            Assert.AreEqual(2, result.Passengers.Count);
        }

    }
}
