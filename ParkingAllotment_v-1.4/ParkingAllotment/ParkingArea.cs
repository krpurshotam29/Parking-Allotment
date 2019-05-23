using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    class ParkingArea
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot;
            ParkingLotSimulator parkingLotSimulator = new ParkingLotSimulator();
            parkingLotSimulator.CreateAllotment(out parkingLot);
            parkingLotSimulator.MainMenu(parkingLot);
        }
    }
}