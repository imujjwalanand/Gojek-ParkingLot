using parking_lot.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Interfaces {
    public interface IParkingService {
        void Execute(string inputSring);
        void CreateParkingLot(int lotSize);
        void Park(Vehicle vehicle);
        void Leave(int slot);
        void GetStatus();
        void GetRegistrationNumsForColour(string colour);
        void GetSlotNumsForColour(string colour);
        void GetslotNumForRegistrationNum(string regNum);
        bool Validate(string command);

    }
}
