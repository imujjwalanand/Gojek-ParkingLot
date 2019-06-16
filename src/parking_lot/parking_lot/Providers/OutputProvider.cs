using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot.Providers {
    public class OutputProvider {
        public void Create(int lotSize) {
            Console.WriteLine("Created a parking lot with {0} slots", lotSize);
        }

        public void Park(int slot) {
            Console.WriteLine("Allocated slot number: {0}", slot);
        }

        public void UnPark(int slot) {
            Console.WriteLine("Slot number {0} is free", slot);
        }

        public void SlotsFull() {
            Console.WriteLine("Sorry, parking lot is full");
        }


    }
}
