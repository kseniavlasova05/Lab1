using System;
using System.Globalization;

namespace MobileDevicesApp
{
    // Базовый класс для всех мобильных устройств
    public class MobileDevice
    {
        private string brand;
        private double screenSize;
        private string resolution;
        private bool hasTouchscreen;

        // Свойства с проверками
        public string Brand
        {
            get => brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Бренд не может быть пустым.");
                brand = value.Trim();
            }
        }

        public double ScreenSize
        {
            get => screenSize;
            set
            {
                if (value < 2.0 || value > 20.0)
                    throw new ArgumentOutOfRangeException(nameof(ScreenSize), "Размер экрана должен быть от 2 до 20 дюймов.");
                screenSize = value;
            }
        }

        public string Resolution
        {
            get => resolution;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Разрешение не может быть пустым.");
                resolution = value.Trim();
            }
        }

        public bool HasTouchscreen
        {
            get => hasTouchscreen;
            set => hasTouchscreen = value;
        }

        // Конструктор инициализирует поля через параметры
        public MobileDevice(string brand = "Unknown", double size = 5.0, string res = "Unknown", bool touch = false)
        {
            Brand = brand;
            ScreenSize = size;
            Resolution = res;
            HasTouchscreen = touch;
        }

        // Вывод информации
        public virtual void PrintInfo()
        {
            Console.WriteLine(GetInfo());
        }

        // Формирование строки с данными
        public virtual string GetInfo()
        {
            return $"Мобильное устройство: {Brand}, Экран: {ScreenSize.ToString(CultureInfo.InvariantCulture)}\", Разрешение: {Resolution}, Сенсорный экран: {(HasTouchscreen ? "Да" : "Нет")}";
        }
    }
}
