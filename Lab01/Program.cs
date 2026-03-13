using System;
// Перевод скорости и вычисление пути
namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вывод заголовка программы
            Console.WriteLine("=== Перевод скорости и вычисление пути ===");
            Console.WriteLine();

            while (true) // Бесконечный цикл для повторного выбора задачи
            {
                // Вывод меню выбора задачи
                Console.WriteLine("Выберите задачу:");
                Console.WriteLine("1 - Задача 1. Перевести скорость из км/ч в м/с");
                Console.WriteLine("2 - Задача 2. Перевести скорость из м/с в км/ч");
                Console.WriteLine("3 - Задача 3. Вычислить путь");
                Console.WriteLine("0 - Выход из программы");
                Console.Write("Ваш выбор (0-3): ");

                string choiceInput = Console.ReadLine(); // Ввод выбора пользователя
                int choice = -1; // Инициализация переменной выбора

                // Проверка, является ли ввод числом
                if (!int.TryParse(choiceInput, out choice)) // Проверка корректности ввода числа
                {
                    Console.WriteLine("Ошибка: введите число (0, 1, 2 или 3).");
                    Console.WriteLine();
                    continue; // Переход к следации цикла
                }

                // Проверка диапазона выбора
                if (choice == 0) // Обработка выхода из программы
                {
                    Console.WriteLine("Выход из программы...");
                    break; // Выход из цикла и завершение программы
                }
                else if (choice == 1) // Выбор задачи 1
                {
                    Task1(); // Вызов метода для задачи 1
                }
                else if (choice == 2) // Выбор задачи 2
                {
                    Task2(); // Вызов метода для задачи 2
                }
                else if (choice == 3) // Выбор задачи 3
                {
                    Task3(); // Вызов метода для задачи 3
                }
                else // Некорректный выбор
                {
                    Console.WriteLine("Ошибка: введите число от 0 до 3.");
                    Console.WriteLine();
                }

                Console.WriteLine(); // Пустая строка для разделения
            }

            // Задержка перед закрытием
            Console.Write("Нажмите любую клавишу для выхода...");
            Console.ReadKey(); // Ожидание нажатши
        }

        // Метод для задачи 1: перевод скорости из км/ч в м/с
        static void Task1()
        {
            Console.WriteLine("--- Задача 1: Перевод скорости из км/ч в м/с ---");
            double speedKmh = GetPositiveDoubleWithLimit("Введите скорость в км/ч: ", 100000); // Ввод положительного числа

            // Формула: v(м/с) = v(км/ч) / 3.6
            double speedMs = speedKmh / 3.6; // Преобразование скорости

            Console.WriteLine($"Скорость в м/с: {speedMs:F2}"); // Вывод результата с 2 знаками после запятой
        }

        // Метод для задачи 2: перевод скорости из м/с в км/ч
        static void Task2()
        {
            Console.WriteLine("--- Задача 2: Перевод скорости из м/с в км/ч ---");
            double speedMsInput = GetPositiveDoubleWithLimit("Введите скорость в м/с: ", 100000); // Ввод положительного числа

            // Формула: v(км/ч) = v(м/с) × 3.6
            double speedKmhOutput = speedMsInput * 3.6; // Преобразование скорости

            Console.WriteLine($"Скорость в км/ч: {speedKmhOutput:F2}"); // Вывод результата с 2 знаками после запятой
        }

        // Метод для задачи 3: вычисление пути
        static void Task3()
        {
            Console.WriteLine("--- Задача 3: Вычисление пути ---");
            double v = GetPositiveDoubleWithLimit("Введите скорость v (в км/ч): ", 100000); // Ввод положительного числа
            double t = GetPositiveDoubleWithLimit("Введите время t (в часах): ", 100000); // Ввод положительного числа

            // Формулы: S(км) = v*t, S(м) = S(км) * 1000
            double distanceKm = v * t; // Путь в км
            double distanceM = distanceKm * 1000; // Путь в метрах
            Console.WriteLine(); // Пустая строка
            Console.WriteLine("=== Результаты задачи 3 ===");
            Console.WriteLine($"Пройденный путь: {distanceKm:F2} км"); // Вывод пути в км
            Console.WriteLine($"Пройденный путь: {distanceM:F2} м"); // Вывод пути в метрах
        }

        // Метод для получения положительного вещественного числа от пользователя с проверкой
        static double GetPositiveDouble(string prompt)
        {
            double value;
            while (true) // Цикл до получения корректного ввода
            {
                Console.Write(prompt);
                string input = Console.ReadLine(); // Чтение строки ввода

                // Проверка на пустую строку или null
                if (string.IsNullOrWhiteSpace(input)) // Проверка пустого ввода
                {
                    Console.WriteLine("Ошибка: введена пустая строка. Введите число.");
                    continue; // Повтор ввода
                }

                // Попытка пре в число
                if (double.TryParse(input, out value)) // Проверка корректности числового формата
                {
                    // Проверка, является ли число положительным
                    if (value >= 0) // Проверка неотрицательного значения
                    {
                        return value; // Возвращаем положительное число
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите неотрицательное число.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
        }

        // Метод для получения положительного вещественного числа от пользователя с проверкой и ограничением
        static double GetPositiveDoubleWithLimit(string prompt, double maxValue)
        {
            double value;
            while (true) // Цикл до получения корректного ввода
            {
                Console.Write(prompt);
                string input = Console.ReadLine(); // Чтение строки ввода

                // Проверка на пустую строку или null
                if (string.IsNullOrWhiteSpace(input)) // Проверка пустого ввода
                {
                    Console.WriteLine("Ошибка: введена пустая строка. Введите число.");
                    continue; // Повтор ввода
                }

                // Попытка преобразовать строку в число
                if (double.TryParse(input, out value)) // Проверка корректности числового формата
                {
                    // Проверка, является ли число положительным
                    if (value >= 0) // Проверка неотрицательного значения
                    {
                        // Проверка, не превышает ли значение максимальное допустимое
                        if (value <= maxValue) // Проверка ограничения на максимальное значение
                        {
                            return value; // Возвращаем положительное число в пределах ограничения
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка: введенное число превышает максимально допустимое значение {maxValue}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите неотрицательное число.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
        }
    }
}
