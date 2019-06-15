using System;
using System.Collections.Generic;

namespace parking_lot {
    public class ParkingLot {
        static Dictionary<string, string> _regToColourMap;
        static Dictionary<int, string> _slotToRegMap;
        static Dictionary<string, bool> _commands;
        static int _lotSize;
        static void Main(string[] args) {
            Initialize();
            _regToColourMap = new Dictionary<string, string>();
            _slotToRegMap = new Dictionary<int, string>();
        }



        public static void Initialize() {
            _commands = new Dictionary<string, bool>();
            _commands.Add(Constants.CREATE_PARKING_LOT_COMMAND, true);
            _commands.Add(Constants.PARK_COMMAND, true);
            _commands.Add(Constants.LEAVE_COMMAND, true);
            _commands.Add(Constants.STATUS_COMMAND, true);
            _commands.Add(Constants.REG_FOR_COLOUR_COMMAND, true);
            _commands.Add(Constants.SLOT_FOR_COLOUR_COMMAND, true);
            _commands.Add(Constants.SLOT_FOR_REG_COMMAND, true);
        }
    }
}
