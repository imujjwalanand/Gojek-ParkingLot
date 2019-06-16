using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Constants {
    public class Commands {
        public const string CREATE_PARKING_LOT_COMMAND = "create_parking_lot";
        public const string PARK_COMMAND = "park";
        public const string LEAVE_COMMAND = "leave";
        public const string STATUS_COMMAND = "status";
        public const string REG_FOR_COLOUR_COMMAND = "registration_numbers_for_cars_with_colour";
        public const string SLOT_FOR_COLOUR_COMMAND = "slot_numbers_for_cars_with_colour";
        public const string SLOT_FOR_REG_COMMAND = "slot_number_for_registration_number";
    }
}
