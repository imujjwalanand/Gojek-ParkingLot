using parking_lot.DTO;
using parking_lot.Exception;
using parking_lot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Providers {
    public class ParkingServiceProvider : IParkingService {
        private int _lotSize = -1;
        Dictionary<string, string> _regToColourMap;
        Dictionary<int, string> _slotToRegMap;
        private OutputProvider output;
        private InputValidationProvider validator;

        public ParkingServiceProvider() {
            this.output = new OutputProvider();
            this.validator = new InputValidationProvider();
        }

        public void Execute(string inputString) {

        }

        public void CreateParkingLot(int lotSize) {
            if(lotSize > 0) {
                this._lotSize = lotSize;
                //Instantiating them here so if create command is called again in an execution, it'll clear the previous parking lot
                _regToColourMap = new Dictionary<string, string>();
                _slotToRegMap = new Dictionary<int, string>();
                output.Create(lotSize);
            } else {
                throw new ParkingLotCreateException(lotSize);
            }
        }

        public void Park(Vehicle vehicle) {

        }

        public void Leave(int slot) {
            throw new NotImplementedException();
        }

        public void GetStatus() {
            throw new NotImplementedException();
        }


        public void GetRegistrationNumsForColour(string colour) {

        }

        public void GetslotNumForRegistrationNum(string regNum) {
            throw new NotImplementedException();
        }

        public void GetSlotNumsForColour(string colour) {
            throw new NotImplementedException();
        }

        public bool Validate(string command) {
            return validator.Validate(command);
        }
    }
}
