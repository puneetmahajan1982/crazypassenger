using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    public class Passenger
    {
        public int Id { get; private set; }

        public int AssignedSeat { get; private set; }

        public int SeatTaken { get; private set; }

        public bool IsSittingOnAllocatedSeat
        {
            get
            {
                return AssignedSeat == SeatTaken;
            }
        }

        public Passenger(int id, int assignedSeat)
        {
            Id = id;
            AssignedSeat = assignedSeat;
        }

        public void TakeSeat(int seatNumber)
        {
            SeatTaken = seatNumber;
        }

    }

}
