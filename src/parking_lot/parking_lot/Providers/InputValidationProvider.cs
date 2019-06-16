using parking_lot.Constants;
using parking_lot.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Providers {
    public class InputValidationProvider {
        Dictionary<string, int> validCommands; //Creating a Dict to store commands and no. of params they require
        public InputValidationProvider() {
            validCommands = new Dictionary<string, int>();
            validCommands.Add(Commands.CREATE_PARKING_LOT_COMMAND, 1);
            validCommands.Add(Commands.PARK_COMMAND, 2);
            validCommands.Add(Commands.LEAVE_COMMAND, 1);
            validCommands.Add(Commands.STATUS_COMMAND, 0);
            validCommands.Add(Commands.REG_FOR_COLOUR_COMMAND, 1);
            validCommands.Add(Commands.SLOT_FOR_COLOUR_COMMAND, 1);
            validCommands.Add(Commands.SLOT_FOR_REG_COMMAND, 1);
        }

        public bool Validate(string inputString) {
            bool valid = true;
            try {
                string[] input = inputString.Split(' ');
                int paramCount;
                if(validCommands.TryGetValue(input[0], out paramCount)) {
                    //Checking to see if the given command has expected no. of parameters
                    switch(input.Length) {
                        case 1:
                            if(paramCount != 0)
                                throw new InvalidCommandException(); //Only Status has input.len = 1 & paramCount 0
                            break;
                        case 2:
                            if(paramCount != 1)
                                throw new InvalidCommandException(); //CreateParkingLot has 1 Params
                            break;
                        case 3:
                            if(paramCount != 2)
                                throw new InvalidCommandException(); //park has 3 params
                            break;
                        default:
                            throw new InvalidCommandException();
                    }
                }

            } catch(ParkingException e) {
                throw new InvalidCommandException();
            }
            return valid;

        }
    }
}
