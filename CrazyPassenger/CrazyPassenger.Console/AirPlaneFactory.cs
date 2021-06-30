using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    public class AirPlaneFactory : IAirPlaneFactory
    {
        public IAirPlane CreateAirPlane(List<Passenger> passengers)
        {
            var plane = new AirPlane(passengers);
            return plane;
        }
    }

    public interface IAirPlaneFactory
    {
        IAirPlane CreateAirPlane(List<Passenger> passengers);
    }
}
