using System;
using System.Linq;

namespace DigitSumSort
{
    internal class Program
    {
        private static void Main()
        {
            // Задание 4
            // Для массива целых реализуйте пользовательскую сортировку по сумме цифр
            // числа по возрастанию и убыванию. Используйте синтаксис запросов LINQ.
            int[] numbers = { 121, 75, 81, 54, 10, 999, 203 };
            var ascending = from number in numbers orderby DigitSum(number) ascending select number;
            var descending = from number in numbers orderby DigitSum(number) descending select number;
            Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));
            Console.WriteLine("По возрастанию суммы цифр: " + string.Join(", ", ascending));
            Console.WriteLine("По убыванию суммы цифр: " + string.Join(", ", descending));
            Console.WriteLine("\nСуммы цифр:");
            foreach (int number in numbers) Console.WriteLine(number + " -> " + DigitSum(number));
            Console.ReadKey();
        }

        private static int DigitSum(int number)
        {
            number = Math.Abs(number);
            int sum = 0;
            do { sum += number % 10; number /= 10; } while (number > 0);
            return sum;
        }
    }
}
