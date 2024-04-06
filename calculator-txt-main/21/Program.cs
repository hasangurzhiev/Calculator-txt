using System;
using System.IO;

class TextCalculator
{
    static void Main()
    {
        string logFileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
        string resultsDirectory = "Results";
        string resultFileName = $"{resultsDirectory}\\result_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";

        int concatenationCount = 0;
        string concatenatedString = string.Empty;

        using (StreamWriter logFile = new StreamWriter(logFileName, true))
        {
            logFile.WriteLine($"Лог-файл для {DateTime.Now}");

            Console.WriteLine("Для завершения введите 'exit'");

            while (true)
            {
                Console.WriteLine("Введите строку:");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                logFile.WriteLine($"Пользователь ввел строку: {input}");

                concatenatedString += input;
                concatenationCount++;

                Console.WriteLine("Текущая сцепленная строка: " + concatenatedString);
            }

            logFile.WriteLine($"Операция сцепления выполнена {concatenationCount} раз(а). Результат: {concatenatedString}");

            if (!Directory.Exists(resultsDirectory))
            {
                Directory.CreateDirectory(resultsDirectory);
            }

            using (StreamWriter resultFile = new StreamWriter(resultFileName))
            {
                resultFile.WriteLine($"Количество строк: {concatenationCount}");
                resultFile.WriteLine($"Сцепленная строка: {concatenatedString}");
            }

            Console.WriteLine($"Файл с результатами сохранен: {resultFileName}");

            logFile.WriteLine($"Приложение завершило работу в {DateTime.Now}");
        }
    }
}