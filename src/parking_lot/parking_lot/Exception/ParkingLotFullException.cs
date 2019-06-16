using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Exception {
    public class ParkingLotFullException : ParkingException {
        public ParkingLotFullException() : base("Sorry, Parking lot is full.") {

        }
    }
}
