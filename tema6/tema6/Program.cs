using System;
using System.Globalization;

namespace WarehouseDateParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Проверка работы с датами склада ****\n");

            // Пример с Parse()
            try
            {
                Console.Write("Введите дату поступления товара (в формате ГГГГ-ММ-ДД ЧЧ:ММ): ");
                string inputDateTime = Console.ReadLine();
                DateTime parsedDateTime = DateTime.Parse(inputDateTime);
                Console.WriteLine($"Дата и время поступления товара через Parse(): {parsedDateTime:yyyy-MM-dd HH:mm}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат даты и времени для Parse().");
            }

            // Пример с ParseExact()
            try
            {
                Console.Write("\nВведите дату проверки товара (формат: дд.MM.yyyy, время указывать не нужно): ");
                string exactDateInput = Console.ReadLine();
                DateTime exactDate = DateTime.ParseExact(exactDateInput, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine($"Дата проверки товара через ParseExact(): {exactDate:yyyy-MM-dd}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат даты для ParseExact().");
            }

            // Пример с TryParse()
            Console.Write("\nВведите дату отправки товара (любой стандартный формат, время указывать не нужно): ");
            string tryParseInput = Console.ReadLine();
            if (DateTime.TryParse(tryParseInput, out DateTime tryParseDate))
            {
                Console.WriteLine($"Дата отправки товара через TryParse(): {tryParseDate:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine("Ошибка: TryParse() не удалось разобрать дату.");
            }

            // Пример с TryParseExact()
            Console.Write("\nВведите дату возврата товара (формат: yyyy/MM/dd HH:mm): ");
            string tryParseExactInput = Console.ReadLine();
            if (DateTime.TryParseExact(tryParseExactInput, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tryParseExactDate))
            {
                Console.WriteLine($"Дата и время возврата товара через TryParseExact(): {tryParseExactDate:yyyy-MM-dd HH:mm}");
            }
            else
            {
                Console.WriteLine("Ошибка: TryParseExact() не удалось разобрать дату и время.");
            }

            Console.WriteLine("\nРабота программы завершена.");
        }
    }
}

