using parking_lot.DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace parking_lot {
    public class ParkingLot {

        static void Main(string[] args) {
            Car car = new Car("Reg1", "Black");
            Console.WriteLine("{0} {1}", car.RegistrationNumber, car.Colour);
            Console.ReadKey();
        }




    }
}
