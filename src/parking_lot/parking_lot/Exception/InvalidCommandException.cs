using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Exception {
    public class InvalidCommandException : ParkingException {
        public InvalidCommandException(string message = null) : base(message + "Please enter a valid command") {

        }
    }
}
