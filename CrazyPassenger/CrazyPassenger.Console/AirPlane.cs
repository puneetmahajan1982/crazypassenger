using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    public interface IAirPlane
    {
        List<Passenger> Passengers { get; set; }
        void BoardPassengers();
        bool IsSeatOccupied(int seatNumber);
    }

    public class AirPlane : IAirPlane
    {
        public List<Passenger> Passengers { get; set; }

        public AirPlane(List<Passenger> passengers)
        {
            Passengers = passengers;
        }

        public void BoardPassengers()
        {
            foreach (var passenger in Passengers)
            {
                var passengerSeat = passenger.AssignedSeat;

                if (passenger.Id == Passengers.First().Id) //CRAZY PASSENGER BOARDING
                {
                    passengerSeat = Passengers.GetRandomSeatNumber(SeatSelectionType.Boarding);
                }
                else if (IsSeatOccupied(passenger.AssignedSeat))
                {
                    passengerSeat = Passengers.GetRandomSeatNumber(SeatSelectionType.Boarding);
                }

                passenger.TakeSeat(passengerSeat);
            }
        }

        public bool IsSeatOccupied(int seatNumber)
        {
            var i = Passengers.Count(x => x.SeatTaken == seatNumber);
            var isSeatOccupied = Passengers.Any(x => x.SeatTaken == seatNumber);
            return isSeatOccupied;
        }

    }

}
