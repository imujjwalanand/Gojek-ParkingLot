using parking_lot.DTO;
using parking_lot.Exception;
using parking_lot.Interfaces;
using parking_lot.Providers;
using System;
using System.Collections.Generic;
using System.IO;

namespace parking_lot {
    public class Program {
        public static IParkingService provider;


        static void Main(string[] args) {
            provider = new ParkingServiceProvider();
            HelperMethods.PrintWelcomeMessage();

            if(args.Length != 0) {
                //Input from a file
                string line;
                try {
                    System.IO.StreamReader file = new StreamReader(args[0]);
                    while((line = file.ReadLine()) != null) {
                        if(provider.Validate(line)) {
                            try {
                                provider.Execute(line);
                            } catch(ParkingException e) {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    file.Close();
                    Console.Read();
                } catch(System.Exception e) {
                    Console.WriteLine(e.Message);
                }

                return;
            } else {
                //Input Interactively
                HelperMethods.PrintCommands();
                while(true) {
                    try {
                        var input = Console.ReadLine();
                        if(input.ToLower().Equals("exit")) {
                            break;
                        } else {
                            if(provider.Validate(input)) {
                                try {
                                    provider.Execute(input);
                                } catch(ParkingException e) {
                                    Console.WriteLine(e.Message);
                                }
                            } else {
                                HelperMethods.PrintCommands();
                            }
                        }

                    } catch(System.Exception e) {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }




    }
}
