using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    public interface ISimulation
    {
        List<Passenger> Passengers { get; }
        void Setup();
        void CreatePassengers();

        bool Run();
    }

    public class Simulation : ISimulation
    {
        public IAirPlaneFactory AirPlaneFactory { get; set; }

        private readonly int _totalAirPlaneSeats;
        public List<Passenger> Passengers { get; private set; } 

        public Simulation(int totalAirPlaneSeats, IAirPlaneFactory airPlaneFactory)
        {
            AirPlaneFactory = airPlaneFactory;
            _totalAirPlaneSeats = totalAirPlaneSeats;
            Passengers = new List<Passenger>();
        }

        public void Setup()
        {
            CreatePassengers();
        }

        public virtual void CreatePassengers()
        {
            for (int i = 1; i <= _totalAirPlaneSeats; i++)
            {
                var randomSeat = Passengers.GetRandomSeatNumber(SeatSelectionType.Allocation);
                Passengers.Add(new Passenger(i, randomSeat));
            }
        }

        public bool Run()
        {
            var plane = AirPlaneFactory.CreateAirPlane(Passengers);
            plane.BoardPassengers();

            var isLastPassengerOnOwnSeat = Passengers.Last().AssignedSeat == Passengers.Last().SeatTaken;
            return isLastPassengerOnOwnSeat;
        }
    }


}
