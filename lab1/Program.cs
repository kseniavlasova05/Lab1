using System;
using System.Collections.Generic;
using System.Globalization;
using MobileDevicesApp;

namespace MobileDevicesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Коллекция для хранения всех устройств
            var devices = new List<MobileDevice>();
            int option;

            do
            {
                // Главное меню программы
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить устройство");
                Console.WriteLine("2. Показать все устройства");
                Console.WriteLine("3. Выход");

                option = ReadInt("Ваш выбор: ", 1, 3);

                switch (option)
                {
                    case 1:
                        AddDevice(devices);
                        break;
                    case 2:
                        PrintDevices(devices);
                        break;
                    case 3:
                        Console.WriteLine("Завершение работы...");
                        break;
                }
            } while (option != 3);
        }

        // Метод для добавления нового устройства
        static void AddDevice(List<MobileDevice> devices)
        {
            Console.WriteLine("\nВыберите тип устройства:");
            Console.WriteLine("1. Базовое мобильное устройство");
            Console.WriteLine("2. Смартфон");
            Console.WriteLine("3. Электронная книга");

            int choice = ReadInt("Ваш выбор: ", 1, 3);

            // Ввод основных характеристик устройства
            string brand = ReadString("Введите бренд: ");
            double screenSize = ReadDouble("Размер экрана (дюймы): ", 2.0, 20.0);
            string resolution = ReadString("Разрешение (например FHD, HD): ");
            bool touch = ReadBool("Сенсорный экран (1 - да, 0 - нет): ");

            MobileDevice ptr = null;

            // Создание объекта выбранного типа с проверкой значений
            switch (choice)
            {
                case 1:
                    ptr = new MobileDevice(brand, screenSize, resolution, touch);
                    break;

                case 2:
                    int cameraMp = ReadInt("Мегапиксели камеры (1-200): ", 1, 200);
                    bool has5G = ReadBool("Поддержка 5G (1 - да, 0 - нет): ");
                    ptr = new Smartphone(brand, screenSize, resolution, touch, cameraMp, has5G);
                    break;

                case 3:
                    bool backlight = ReadBool("Подсветка (1 - да, 0 - нет): ");
                    int memory = ReadInt("Память (1-1024 ГБ): ", 1, 1024);
                    ptr = new EBook(brand, screenSize, resolution, touch, backlight, memory);
                    break;
            }

            devices.Add(ptr);
            Console.WriteLine("Устройство добавлено!");
        }

        // Метод для вывода всех устройств
        static void PrintDevices(List<MobileDevice> devices)
        {
            Console.WriteLine("\nСписок устройств:");
            if (devices.Count == 0)
            {
                Console.WriteLine("(пусто)");
                return;
            }

            foreach (var d in devices)
            {
                d.PrintInfo();
            }
        }

        // Метод для ввода непустой строки
        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Ошибка: строка не может быть пустой. Повторите ввод: ");
                input = Console.ReadLine() ?? "";
            }
            return input.Trim();
        }

        // Метод для ввода целого числа с проверкой диапазона
        static int ReadInt(string prompt, int minAllowed = int.MinValue, int maxAllowed = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string raw = Console.ReadLine() ?? "";
                if (int.TryParse(raw.Trim(), out int value))
                {
                    if (value < minAllowed || value > maxAllowed)
                    {
                        Console.WriteLine($"Ошибка: значение должно быть в диапазоне [{minAllowed}..{maxAllowed}].");
                        continue;
                    }
                    return value;
                }
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        // Метод для ввода вещественного числа с проверкой диапазона
        static double ReadDouble(string prompt, double minAllowed = double.MinValue, double maxAllowed = double.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string raw = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

                if (double.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                {
                    if (value < minAllowed || value > maxAllowed)
                    {
                        Console.WriteLine($"Ошибка: значение должно быть в диапазоне [{minAllowed}..{maxAllowed}].");
                        continue;
                    }
                    return value;
                }
                Console.WriteLine("Ошибка: введите число (например 5.5).");
            }
        }

        // Метод для ввода логического значения
        static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string raw = (Console.ReadLine() ?? "").Trim().ToLower();
                if (raw == "1" || raw == "да" || raw == "y")
                    return true;
                if (raw == "0" || raw == "нет" || raw == "n")
                    return false;

                Console.WriteLine("Ошибка: введите 1 (да) или 0 (нет).");
            }
        }
    }
}
