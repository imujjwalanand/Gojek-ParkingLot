using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.DTO {
    public class Car : Vehicle {
        public Car(string regNo, string colour) : base(regNo, colour) {
        }
    }
}
