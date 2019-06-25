------------- README.MD -------------
Welcome to Gojek's Parking Lot Program

I've implemented the Parking Lot problem to the best of my abilities in C# Language as a .NET Core 2.2 Console Application

#Project Requirements

*.NET core CLI 2.0

#Steps to run the program

To install the .NET Core SDK and Runtime packages and allow permissions, please run
$ ./install_dotnet_sdk_and_runtime.sh (Removed packages from the assets folder because of the size, please install or download from MSFT)

if it says permission denied, please run the following command in your terminal to grant access
$ sudo chmod 755 'install_dotnet_sdk_and_runtime.sh' (Removed packages from the assets folder because of the size, please install or download from MSFT)

Once .NET Core sdk and runtime packages are installed, please run the following commands as per their usage

$ ./setup.sh ----> To build the solution
$ ./run_functional_tests.sh ----> To run the functional Unit Tests 
$ ./parking_lot.sh ----> To Run the Parking Lot application in Interactive Mode

$ ./parking_lot.sh input.txt ----> To run the Parking Lot application take input from ./src/Gojek.parking_lot/parking_lot/input.txt