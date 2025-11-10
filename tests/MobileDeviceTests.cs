using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using MobileDevicesApp;

namespace MobileDevicesApp.Tests
{
    // Тесты для базового класса MobileDevice
    [TestClass]
    public class MobileDeviceTests
    {
        // Проверка корректной инициализации конструктора
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var device = new MobileDevice("Samsung", 5.5, "HD", true);
            Assert.AreEqual("Samsung", device.Brand);
            Assert.AreEqual(5.5, device.ScreenSize);
            Assert.AreEqual("HD", device.Resolution);
            Assert.IsTrue(device.HasTouchscreen);
        }

        // Проверка метода GetInfo
        [TestMethod]
        public void GetInfo_ReturnsCorrectString()
        {
            var device = new MobileDevice("Samsung", 5.5, "HD", true);
            string info = device.GetInfo();
            StringAssert.Contains(info, "Samsung");
            StringAssert.Contains(info, "5.5");
            StringAssert.Contains(info, "HD");
            StringAssert.Contains(info, "Да");
        }

        // Проверка метода PrintInfo
        [TestMethod]
        public void PrintInfo_WritesCorrectOutput()
        {
            var device = new MobileDevice("Samsung", 5.5, "HD", true);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                device.PrintInfo();
                string output = sw.ToString().Trim();
                StringAssert.Contains(output, "Samsung");
                StringAssert.Contains(output, "5.5");
                StringAssert.Contains(output, "HD");
                StringAssert.Contains(output, "Да");
            }
        }

        // Проверка сеттера Brand
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Brand_Invalid_Throws()
        {
            var device = new MobileDevice();
            device.Brand = "   ";
        }

        // Проверка сеттера ScreenSize
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ScreenSize_Invalid_Throws()
        {
            var device = new MobileDevice();
            device.ScreenSize = 1;
        }

        // Проверка сеттера Resolution
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Resolution_Invalid_Throws()
        {
            var device = new MobileDevice();
            device.Resolution = "";
        }

        // Проверка корректного присвоения HasTouchscreen
        [TestMethod]
        public void HasTouchscreen_SetValid()
        {
            var device = new MobileDevice();
            device.HasTouchscreen = true;
            Assert.IsTrue(device.HasTouchscreen);
            device.HasTouchscreen = false;
            Assert.IsFalse(device.HasTouchscreen);
        }
    }
}
