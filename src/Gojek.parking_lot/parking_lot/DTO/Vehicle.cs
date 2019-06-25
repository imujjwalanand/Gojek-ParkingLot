using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.DTO {
    public class Vehicle {
        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }

        public Vehicle(string regNo, string colour) {
            RegistrationNumber = regNo;
            Colour = colour;
        }

    }
}
