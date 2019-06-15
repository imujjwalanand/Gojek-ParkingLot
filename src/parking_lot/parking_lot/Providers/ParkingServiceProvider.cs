using parking_lot.DTO;
using parking_lot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Providers {
    public class ParkingServiceProvider : IParkingService {
        private int _lotSize;
        public void CreateParkingLot(int lotSize) {
            this._lotSize = lotSize;
        }

        public void GetRegistrationNumsForColour(string colour) {
            throw new NotImplementedException();
        }

        public void GetslotNumForRegistrationNum(string regNum) {
            throw new NotImplementedException();
        }

        public void GetSlotNumsForColour(string colour) {
            throw new NotImplementedException();
        }

        public void GetStatus() {
            throw new NotImplementedException();
        }

        public void Leave(int slot) {
            throw new NotImplementedException();
        }

        public void Park(Vehicle vehicle) {
            throw new NotImplementedException();
        }
    }
}
