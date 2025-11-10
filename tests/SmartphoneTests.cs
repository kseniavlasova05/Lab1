using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using MobileDevicesApp;

namespace MobileDevicesApp.Tests
{
    // Тесты для класса Smartphone
    [TestClass]
    public class SmartphoneTests
    {
        // Проверка корректной инициализации конструктора
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var phone = new Smartphone("Apple", 6.1, "FHD", true, 48, true);
            Assert.AreEqual("Apple", phone.Brand);
            Assert.AreEqual(6.1, phone.ScreenSize);
            Assert.AreEqual("FHD", phone.Resolution);
            Assert.IsTrue(phone.HasTouchscreen);
            Assert.AreEqual(48, phone.CameraMP);
            Assert.IsTrue(phone.Has5G);
        }

        // Проверка метода GetInfo
        [TestMethod]
        public void GetInfo_ReturnsCorrectString()
        {
            var phone = new Smartphone("Apple", 6.1, "FHD", true, 48, true);
            string info = phone.GetInfo();
            StringAssert.Contains(info, "Apple");
            StringAssert.Contains(info, "6.1");
            StringAssert.Contains(info, "FHD");
            StringAssert.Contains(info, "48");
            StringAssert.Contains(info, "5G");
        }

        // Проверка метода PrintInfo
        [TestMethod]
        public void PrintInfo_WritesCorrectOutput()
        {
            var phone = new Smartphone("Apple", 6.1, "FHD", true, 48, true);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                phone.PrintInfo();
                string output = sw.ToString().Trim();
                StringAssert.Contains(output, "Apple");
                StringAssert.Contains(output, "6.1");
                StringAssert.Contains(output, "FHD");
                StringAssert.Contains(output, "48");
                StringAssert.Contains(output, "5G");
            }
        }

        // Проверка сеттера CameraMP
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CameraMP_Invalid_Throws()
        {
            var phone = new Smartphone();
            phone.CameraMP = 300;
        }

        // Проверка корректного присвоения CameraMP
        [TestMethod]
        public void CameraMP_SetValid()
        {
            var phone = new Smartphone();
            phone.CameraMP = 48;
            Assert.AreEqual(48, phone.CameraMP);
        }

        // Проверка корректного присвоения Has5G
        [TestMethod]
        public void Has5G_SetValid()
        {
            var phone = new Smartphone();
            phone.Has5G = true;
            Assert.IsTrue(phone.Has5G);
            phone.Has5G = false;
            Assert.IsFalse(phone.Has5G);
        }
    }
}
