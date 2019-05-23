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
            ParkVehicle parkVehicle = new ParkVehicle();
            parkVehicle.CreateAllotment(out parkingLot);
            parkVehicle.MainMenu(parkingLot);
        }
    }
}