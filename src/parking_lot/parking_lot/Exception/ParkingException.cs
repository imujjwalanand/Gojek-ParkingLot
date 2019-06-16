using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Exception {
    public class ParkingException : System.Exception {
        string _message;
        public ParkingException(string message) : base(message) {
            this._message = message;
        }

    }
}
