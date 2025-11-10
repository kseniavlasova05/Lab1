using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using MobileDevicesApp;

namespace MobileDevicesApp.Tests
{
    // Тесты для класса EBook
    [TestClass]
    public class EBookTests
    {
        // Проверка корректной инициализации конструктора
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var book = new EBook("Amazon", 7, "HD", false, true, 32);
            Assert.AreEqual("Amazon", book.Brand);
            Assert.AreEqual(7, book.ScreenSize);
            Assert.AreEqual("HD", book.Resolution);
            Assert.IsFalse(book.HasTouchscreen);
            Assert.IsTrue(book.HasBacklight);
            Assert.AreEqual(32, book.MemoryGB);
        }

        // Проверка метода GetInfo
        [TestMethod]
        public void GetInfo_ReturnsCorrectString()
        {
            var book = new EBook("Amazon", 7, "HD", false, true, 32);
            string info = book.GetInfo();
            StringAssert.Contains(info, "Amazon");
            StringAssert.Contains(info, "7");
            StringAssert.Contains(info, "HD");
            StringAssert.Contains(info, "Подсветка");
            StringAssert.Contains(info, "Память");
        }

        // Проверка метода PrintInfo
        [TestMethod]
        public void PrintInfo_WritesCorrectOutput()
        {
            var book = new EBook("Amazon", 7, "HD", false, true, 32);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                book.PrintInfo();
                string output = sw.ToString().Trim();
                StringAssert.Contains(output, "Amazon");
                StringAssert.Contains(output, "7");
                StringAssert.Contains(output, "HD");
                StringAssert.Contains(output, "Подсветка");
                StringAssert.Contains(output, "Память");
            }
        }

        // Проверка сеттера MemoryGB
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MemoryGB_Invalid_Throws()
        {
            var book = new EBook();
            book.MemoryGB = 2000;
        }

        // Проверка корректного присвоения MemoryGB
        [TestMethod]
        public void MemoryGB_SetValid()
        {
            var book = new EBook();
            book.MemoryGB = 32;
            Assert.AreEqual(32, book.MemoryGB);
        }

        // Проверка корректного присвоения HasBacklight
        [TestMethod]
        public void HasBacklight_SetValid()
        {
            var book = new EBook();
            book.HasBacklight = true;
            Assert.IsTrue(book.HasBacklight);
            book.HasBacklight = false;
            Assert.IsFalse(book.HasBacklight);
        }
    }
}
