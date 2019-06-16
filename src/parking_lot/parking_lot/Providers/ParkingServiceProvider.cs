using parking_lot.Constants;
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
            string[] inputs = inputString.Split(' ');
            switch(inputs[0]) {
                case Commands.CREATE_PARKING_LOT_COMMAND: {
                        CreateParkingLot(Int32.Parse(inputs[1]));
                        break;
                    }
                case Commands.PARK_COMMAND: {
                        Vehicle vehicle = new Vehicle(inputs[1], inputs[2]);
                        Park(vehicle);
                        break;
                    }
                case Commands.LEAVE_COMMAND: {
                        try {
                            Leave(Int32.Parse(inputs[1]));
                        } catch(System.Exception e) {
                            throw new ParkingException("Please provide valid input for slot number");
                        }
                        break;
                    }
                case Commands.REG_FOR_COLOUR_COMMAND: {
                        GetRegistrationNumsForColour(inputs[1]);
                        break;
                    }
                case Commands.SLOT_FOR_COLOUR_COMMAND: {
                        GetSlotNumsForColour(inputs[1]);
                        break;
                    }
                case Commands.SLOT_FOR_REG_COMMAND: {
                        GetslotNumForRegistrationNum(inputs[1]);
                        break;
                    }
                case Commands.STATUS_COMMAND: {
                        GetStatus();
                        break;
                    }
                default:
                    throw new ParkingException("Please enter a valid command");
            }
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
            validParkingLotExists();
            string reg = vehicle.RegistrationNumber;
            string colour = vehicle.Colour;
            for(int i = 1; i <= _lotSize; i++) {
                string temp;
                bool emptySlot = _slotToRegMap.TryGetValue(i, out temp);
                if(!emptySlot) {
                    _slotToRegMap.Add(i, reg);
                    _regToColourMap.Add(reg, colour);
                    output.Park(i);
                    return;
                }
            }
            throw new ParkingLotFullException();
        }

        public void Leave(int slot) {
            validParkingLotExists();
            if(slot > _lotSize || slot < 1) {
                throw new InvalidCommandException("The given slot doesn't exist. ");
            }
            string regNo;
            if(_slotToRegMap.TryGetValue(slot, out regNo)) {
                _slotToRegMap.Remove(slot);
                _regToColourMap.Remove(regNo);
                output.UnPark(slot);
                return;
            } else {
                throw new ParkingException("No car is parked in the mentioned slot. ");
            }
        }

        public void GetStatus() {
            validParkingLotExists();
            //Finding the greatest string length and beautifying the outout in a table format
            int slotLength = ParkingLotStrings.SlotNumberText.Length, regNoLength = ParkingLotStrings.RegistrationNumberText.Length;
            foreach(var slot in _slotToRegMap.Keys) {
                slotLength = (slot.ToString().Length > slotLength) ? slot.ToString().Length : slotLength;
                regNoLength = (_slotToRegMap[slot].Length > regNoLength) ? _slotToRegMap[slot].Length : regNoLength;
            }
            //Adding a gap of 7 spaces between the columns
            string slotGap = "";
            for(int i = 0; i < (slotLength - ParkingLotStrings.SlotNumberText.Length + 7); i++) {
                slotGap += " ";
            }

            string regGap = "";
            for(int i = 0; i < regNoLength - ParkingLotStrings.RegistrationNumberText.Length + 7; i++) {
                regGap += " ";
            }

            output.Print(HelperMethods.BeautifyStatusOutput(ParkingLotStrings.SlotNumberText, slotLength) + HelperMethods.BeautifyStatusOutput(ParkingLotStrings.RegistrationNumberText, regNoLength) + ParkingLotStrings.ColourText);
            foreach(var key in _slotToRegMap.Keys) {
                output.Print(string.Format("{0}{1}{2}", HelperMethods.BeautifyStatusOutput(key.ToString(), slotLength), HelperMethods.BeautifyStatusOutput(_slotToRegMap[key], regNoLength), _regToColourMap[_slotToRegMap[key]]));
            }
            return;
        }


        public void GetRegistrationNumsForColour(string colour) {
            validParkingLotExists();
            colour = colour.ToLower();
            List<string> cars = new List<string>();
            foreach(var reg in _regToColourMap.Keys) {
                if(_regToColourMap[reg].ToLower().Equals(colour)) {
                    cars.Add(reg);
                }
            }
            if(cars.Count == 0) {
                throw new NotFoundException("No Cars present for given Colour. ");
            }
            output.Print(HelperMethods.CommaSeparatedList(cars));
            return;
        }

        public void GetslotNumForRegistrationNum(string regNum) {
            validParkingLotExists();
            regNum = regNum.ToLower();
            foreach(var slot in _slotToRegMap.Keys) {
                if(_slotToRegMap[slot].ToLower().Equals(regNum)) {
                    output.Print(slot.ToString());
                    return;
                }
            }
            throw new NotFoundException("No Cars present for given Registration Number. ");
        }

        public void GetSlotNumsForColour(string colour) {
            validParkingLotExists();
            colour = colour.ToLower();
            List<string> cars = new List<string>();
            foreach(var reg in _regToColourMap.Keys) {
                if(_regToColourMap[reg].ToLower().Equals(colour)) {
                    cars.Add(reg);
                }
            }
            if(cars.Count == 0) {
                throw new NotFoundException("No cars found with given colour. ");
            }

            List<string> slots = new List<string>();
            foreach(var slot in _slotToRegMap.Keys) {
                if(cars.Contains(_slotToRegMap[slot])) {
                    slots.Add(slot.ToString());
                }
            }

            if(slots.Count == 0) {
                throw new NotFoundException("No cars found with given colour. ");
            }
            output.Print(HelperMethods.CommaSeparatedList(slots));
            return;
        }

        public bool Validate(string command) {
            return validator.Validate(command);
        }

        private bool validParkingLotExists() {
            if(_lotSize == -1) {
                throw new ParkingException("You must need to create the parking lot first");
            }
            return true;
        }
    }
}
