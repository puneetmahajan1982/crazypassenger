using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    public static class Extensions
    {
        public static int GetRandomSeatNumber(this List<Passenger> passengers, SeatSelectionType selectionType)
        {
            int minN = 1;
            int maxN = 100 + 1;

            IEnumerable<int> exNumbers;

            if (selectionType == SeatSelectionType.Boarding)
            {
                exNumbers = from p in passengers
                            where p.SeatTaken > 0
                            select p.SeatTaken;
            }
            else
            {
                exNumbers = from p in passengers
                            where p.AssignedSeat > 0
                            select p.AssignedSeat;
            }

            //First seat
            if (!exNumbers.Any())
            {
                return StaticRandom.Instance.Next(minN, maxN);
            }

            int result = exNumbers.First();
            while (exNumbers.ToList().Contains(result))
            {
                result = StaticRandom.Instance.Next(minN, maxN);
            }

            return result;
        }
    }
}
