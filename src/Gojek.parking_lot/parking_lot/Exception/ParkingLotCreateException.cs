using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Exception {
    public class ParkingLotCreateException : ParkingException {
        public ParkingLotCreateException(int i) : base(string.Format("Can not create a parking lot of invalid size : {0}", i.ToString())) {
        }
    }
}
