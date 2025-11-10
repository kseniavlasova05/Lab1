using System;
using System.Globalization;

namespace MobileDevicesApp
{
    // Класс смартфона
    public class Smartphone : MobileDevice
    {
        private int cameraMP;
        private bool has5G;

        // Разрешение камеры
        public int CameraMP
        {
            get => cameraMP;
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentOutOfRangeException(nameof(CameraMP), "Мегапиксели камеры должны быть от 1 до 200.");
                cameraMP = value;
            }
        }

        // Наличие поддержки 5G
        public bool Has5G
        {
            get => has5G;
            set => has5G = value;
        }

        // Конструктор инициализирует свойства
        public Smartphone(string brand = "Unknown", double size = 6.0, string res = "FHD", bool touch = true, int mp = 12, bool g5 = false)
            : base(brand, size, res, touch)
        {
            CameraMP = mp;
            Has5G = g5;
        }

        // Вывод информации
        public override void PrintInfo()
        {
            Console.WriteLine(GetInfo());
        }

        // Возвращает строку с информацией о смартфоне 
        public override string GetInfo()
        {
            return $"Смартфон: {Brand}, Экран: {ScreenSize.ToString(CultureInfo.InvariantCulture)}\", Разрешение: {Resolution}, Камера: {CameraMP} МП, 5G: {(Has5G ? "Да" : "Нет")}";
        }
    }
}
