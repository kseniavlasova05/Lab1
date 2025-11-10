using System;
using System.Globalization;

namespace MobileDevicesApp
{
    // Класс электронных книг
    public class EBook : MobileDevice
    {
        private bool hasBacklight;
        private int memoryGB;

        // Наличие подсветки
        public bool HasBacklight
        {
            get => hasBacklight;
            set => hasBacklight = value;
        }

        // Объем памяти 
        public int MemoryGB
        {
            get => memoryGB;
            set
            {
                if (value < 1 || value > 1024)
                    throw new ArgumentOutOfRangeException(nameof(MemoryGB), "Память должна быть в диапазоне от 1 до 1024 ГБ.");
                memoryGB = value;
            }
        }

        // Конструктор инициализирует базовые и собственные свойства
        public EBook(string brand = "Unknown", double size = 7.0, string res = "HD", bool touch = false, bool backlight = false, int mem = 8)
            : base(brand, size, res, touch)
        {
            HasBacklight = backlight;
            MemoryGB = mem;
        }

        // Переопределённый метод вывода информации на экран
        public override void PrintInfo()
        {
            Console.WriteLine(GetInfo());
        }

        // Возвращает строку с информацией об электронной книге
        public string GetInfo()
        {
            return $"Электронная книга: {Brand}, Экран: {ScreenSize.ToString(CultureInfo.InvariantCulture)}\", Разрешение: {Resolution}, Подсветка: {(HasBacklight ? "Да" : "Нет")}, Память: {MemoryGB} ГБ";
        }
    }
}
