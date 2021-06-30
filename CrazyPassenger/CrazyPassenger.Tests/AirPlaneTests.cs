using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyPassenger.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyPassenger.Tests
{
    [TestClass]
    public class AirPlaneTests
    {

        [TestMethod]
        public void IsSeatOccupiedReturnsFalseWhenSeatIsVacant()
        {
            //arrange
            var passengers = new List<Passenger>()
            {
                new Passenger(1, 1),
                new Passenger(2, 2),
            };

            passengers[0].TakeSeat(1);

            var airplane = new AirPlane(passengers);

            //act
            var result = airplane.IsSeatOccupied(2);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSeatOccupiedReturnsTrueWhenSeatIsTaken()
        {
            //arrange
            var passengers = new List<Passenger>()
            {
                new Passenger(1, 1),
                new Passenger(2, 2),
            };

            passengers[0].TakeSeat(1);

            var airplane = new AirPlane(passengers);

            //act
            var result = airplane.IsSeatOccupied(1);

            //assert
            Assert.IsTrue(result);
        }
    }
}
