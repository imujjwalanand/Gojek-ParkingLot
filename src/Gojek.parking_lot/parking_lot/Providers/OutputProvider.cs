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

        //Generic Print Message for dynamic I/O
        public void Print(string s) {
            Console.WriteLine(s);
        }


    }
}
