# Readme.Md (Welcome to Gojek's Parking Lot Problem)
I've implemented the Parking Lot problem to the best of my abilities in C# Language as a .NET Core 2.2 Console Application

## Project Requirements
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1) > 2.0 
- [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/2.1) > 2.0

#### *Note : You can either download the SDK and Runtime packages or directly download the .pkg files(for OSx) and place them under bin/assets/ folder, then run the following scripts*
```$ ./install_dotnet_sdk_and_runtime.sh```

#### *Note : if it says permission denied, please run the following command in your terminal to grant access*
```$ sudo chmod 755 'install_dotnet_sdk_and_runtime.sh'```

## Once .NET Core sdk and runtime packages are installed, please run the following commands as per their usage
```
$ ./setup.sh ----> To build the solution
$ ./run_functional_tests.sh ----> To run the functional Unit Tests 
$ ./parking_lot.sh ----> To Run the Parking Lot application in Interactive Mode

$ ./parking_lot.sh input.txt ----> To run the Parking Lot application take input from ./src/Gojek.parking_lot/parking_lot/input.txt
```
