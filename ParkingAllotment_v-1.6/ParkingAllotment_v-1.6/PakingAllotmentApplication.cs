using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    class PakingAllotmentApplication
    {
        static void Main(string[] args)
        {
            ParkingAllotmentSimulator parkingAllotmentSimulator = new ParkingAllotmentSimulator();
            ParkingLot parkingLot;
            parkingAllotmentSimulator.MakeAllotment(out parkingLot);
            parkingAllotmentSimulator.MainMenu(parkingLot);
        }
    }
}