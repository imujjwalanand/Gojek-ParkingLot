using Microsoft.VisualStudio.TestTools.UnitTesting;
using parking_lot.DTO;
using parking_lot.Exception;
using parking_lot.Providers;
using System;
using System.IO;

namespace parking_lot.Tests {
    [TestClass]
    public class ParkingServiceProviderTest {
        ParkingServiceProvider provider;
        StringWriter sw;
        [TestInitialize]
        public void Init() {
            provider = new ParkingServiceProvider();
            sw = new StringWriter();
            Console.SetOut(sw);
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingException))]
        public void ParkingServiceProvider_InvalidCommand_ShouldNotExecute() {
            provider.Execute("Invalid Command");
            Assert.IsTrue(sw.ToString().Contains("Please enter a valid command"));
        }

        [TestMethod]
        public void ParkingServiceProvider_ShouldCreateParkingLotTest() {
            provider.Execute("create_parking_lot 3");
            Assert.IsTrue(sw.ToString().Contains("Created a parking lot with 3 slots"));
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingLotCreateException))]
        public void ParkingServiceProvider_ShouldNotCreateParkingLotInvalidSizeTest() {
            provider.Execute("create_parking_lot -1");
        }

        [TestMethod]
        public void ParkingServiceProvider_ShouldParkTest() {
            provider.Execute("create_parking_lot 1");
            provider.Execute("park Reg1 Blue");
            Assert.IsTrue(sw.ToString().Contains("Allocated slot number: 1"));
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingLotFullException))]
        public void ParkingServiceProvider_ShouldnotPark_SlotsFullTest() {
            provider.Execute("create_parking_lot 1");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Black");
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingException))]
        public void ParkingServiceProvider_ShouldnotPark_NoParkingLotExistsTest() {
            provider.Execute("park Reg1 Blue");
            Assert.IsTrue(sw.ToString().Contains("You must need to create the parking lot first"));
        }

        [TestMethod]
        public void ParkingServiceProvider_ShouldUnParkTest() {
            provider.Execute("create_parking_lot 1");
            provider.Execute("park Reg1 Blue");
            provider.Execute("leave 1");
            Assert.IsTrue(sw.ToString().Contains("Slot number 1 is free"));
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingException))]
        public void ParkingSerivceProvider_InvalidLeaveCommandTest() {
            provider.Execute("create_parking_lot 1");
            provider.Execute("park Reg1 Blue");
            provider.Execute("leave -1");
            Assert.IsTrue(sw.ToString().Contains("The given slot doesn't exist. "));
        }

        [TestMethod]
        [ExpectedException(typeof(ParkingException))]
        public void ParkingServiceProvider_AlreadyEmptySlotToUnParkTest() {
            provider.Execute("create_parking_lot 1");
            provider.Execute("park Reg1 Blue");
            provider.Execute("leave 1");
            provider.Execute("leave 1");
            Assert.IsTrue(sw.ToString().Contains("No car is parked in the mentioned slot. "));
        }

        [TestMethod]
        public void ParkingServiceProvider_GetStatusTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Black");
            provider.Execute("park Reg3 White");
            provider.Execute("park Reg4 Red");
            provider.Execute("status");
            string expectedStatus = @"Slot No.     Registration No.     Colour
1            Reg1                 Blue
2            Reg2                 Black
3            Reg3                 White
4            Reg4                 Red";
            Assert.IsTrue(sw.ToString().Contains(expectedStatus));
        }

        [TestMethod]
        public void ParkingServiceProvider_RegNoForColour_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("registration_numbers_for_cars_with_colour Blue");
            Assert.IsTrue(sw.ToString().Contains("Reg1, Reg2, Reg3"));
        }

        [TestMethod]
        public void ParkingServiceProvider_RegNoForColourCaseInsensitiveQuery_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 blue");
            provider.Execute("park Reg2 BLue");
            provider.Execute("park Reg3 blUE");
            provider.Execute("park Reg4 BLUE");
            provider.Execute("registration_numbers_for_cars_with_colour bLuE");
            Assert.IsTrue(sw.ToString().Contains("Reg1, Reg2, Reg3, Reg4"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void ParkingServiceProvider_RegNoForColourNotFound_ShouldNotReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("registration_numbers_for_cars_with_colour White");
            Assert.IsTrue(sw.ToString().Contains("No Cars present for given Colour. "));
        }

        [TestMethod]
        public void ParkingServiceProvider_SlotNoForColour_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("slot_numbers_for_cars_with_colour Blue");
            Assert.IsTrue(sw.ToString().Contains("1, 2, 3"));
        }

        [TestMethod]
        public void ParkingServiceProvider_SlotNoForColourCaseInsensitiveQuery_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 blue");
            provider.Execute("park Reg2 BLue");
            provider.Execute("park Reg3 blUE");
            provider.Execute("park Reg4 BLUE");
            provider.Execute("slot_numbers_for_cars_with_colour bLuE");
            Assert.IsTrue(sw.ToString().Contains("1, 2, 3, 4"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void ParkingServiceProvider_SlotNoForColourNotFound_ShouldNotReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("slot_numbers_for_cars_with_colour White");
            Assert.IsTrue(sw.ToString().Contains("No Cars present for given Colour. "));
        }

        [TestMethod]
        public void ParkingServiceProvider_SlotNoForRegNo_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("slot_number_for_registration_number Reg2");
            Assert.IsTrue(sw.ToString().Contains("2"));
        }

        [TestMethod]
        public void ParkingServiceProvider_SlotNoForRegNoCaseInsensitive_ShouldReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park REG2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("slot_number_for_registration_number reg2");
            Assert.IsTrue(sw.ToString().Contains("2"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void ParkingServiceProvider_SlotNoForRegNoNotFound_ShouldNotReturnTest() {
            provider.Execute("create_parking_lot 4");
            provider.Execute("park Reg1 Blue");
            provider.Execute("park Reg2 Blue");
            provider.Execute("park Reg3 Blue");
            provider.Execute("park Reg4 Red");
            provider.Execute("slot_number_for_registration_number InvalidRegNo");
            Assert.IsTrue(sw.ToString().Contains("No Cars present for given Registration Number. "));
        }

    }
}
