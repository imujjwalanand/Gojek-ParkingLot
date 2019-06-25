using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot {
    public class HelperMethods {
        /// <summary>
        /// Helper method to beautify the status outpur so that every entry is aligned even for varying numbers of lenghts of values(Regn No., Colour etc.)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string BeautifyStatusOutput(string first, int second) {
            int n = second + 5 - first.Length;
            string s = string.Empty;
            for(int i = 0; i < n; i++) {
                s += " ";
            }
            return first + s;
        }

        public static void PrintWelcomeMessage() {
            Console.WriteLine("\n\n");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------\n");
            Console.WriteLine("-------------  Welcome to GOJEK Parking Lot  -------------\n");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n\n");
        }

        public static void PrintCommands() {
            Console.WriteLine("\n\nPlease enter any of the below commands and enter 'exit' to EXIT");
            Console.WriteLine("1) To create a Parking Lot of size n ----> create_parking_lot {lotSize}");
            Console.WriteLine("2) To Park a car in the nearest slot ----> park {carRegistrationNumber} {carColour}");
            Console.WriteLine("3) To Remove a car from a given slot ----> leave {slotNumber}");
            Console.WriteLine("4) To Get Parking lot status ----> status");
            Console.WriteLine("5) To Get Registration Numbers for cars with Colour ----> registration_numbers_for_cars_with_colour {colour}");
            Console.WriteLine("5) To Get Slot Numbers for cars with Colour ----> slot_numbers_for_cars_with_colour {colour}");
            Console.WriteLine("5) To Get Slot Number for cars with Registration Number ----> slot_number_for_registration_number {RegistrationNumber}");
            Console.WriteLine("\nEnter 'exit' to EXIT");
        }

        public static string CommaSeparatedList(List<string> list) {
            string ans = "";
            for(int i = 0; i < list.Count; i++) {
                ans += list[i];
                if(i != list.Count - 1) {
                    ans += ", ";
                }
            }
            return ans;
        }
    }
}
