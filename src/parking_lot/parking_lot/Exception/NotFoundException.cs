using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Exception {
    public class NotFoundException : ParkingException {
        public NotFoundException(string message = null) : base(message + "Not Found") {

        }
    }
}
