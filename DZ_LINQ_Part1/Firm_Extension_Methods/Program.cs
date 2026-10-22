using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmExtensionMethods
{
    internal class Firm
    {
        public string Name { get; set; } public DateTime FoundationDate { get; set; } public string BusinessProfile { get; set; }
        public string Director { get; set; } public int EmployeesCount { get; set; } public string Address { get; set; }
        public Firm(string name, DateTime date, string profile, string director, int employees, string address) { Name = name; FoundationDate = date; BusinessProfile = profile; Director = director; EmployeesCount = employees; Address = address; }
        public override string ToString() { return Name + " | " + BusinessProfile + " | " + Director + " | " + EmployeesCount + " | " + Address; }
    }

    internal class Program
    {
        private static void Main()
        {
            // Задание 2
            // Реализуйте запросы из первого задания с использованием синтаксиса
            // методов расширений LINQ: Where, Select и другие методы.
            Firm[] firms = CreateFirms();
            Show("Все фирмы", firms.Select(firm => firm));
            Show("Food в названии", firms.Where(firm => firm.Name.Contains("Food")));
            Show("Маркетинг", firms.Where(firm => firm.BusinessProfile == "Marketing"));
            Show("Маркетинг или IT", firms.Where(firm => firm.BusinessProfile == "Marketing" || firm.BusinessProfile == "IT"));
            Show("Больше 100 сотрудников", firms.Where(firm => firm.EmployeesCount > 100));
            Show("От 100 до 300 сотрудников", firms.Where(firm => firm.EmployeesCount >= 100 && firm.EmployeesCount <= 300));
            Show("Лондон", firms.Where(firm => firm.Address.Contains("London")));
            Show("Директор White", firms.Where(firm => firm.Director.EndsWith("White")));
            Show("Старше двух лет", firms.Where(firm => firm.FoundationDate < DateTime.Today.AddYears(-2)));
            Show("Основаны 123 дня назад", firms.Where(firm => (DateTime.Today - firm.FoundationDate).Days == 123));
            Show("Black и White", firms.Where(firm => firm.Director.EndsWith("Black") && firm.Name.Contains("White")));
            Console.ReadKey();
        }
        private static Firm[] CreateFirms() { return new Firm[] { new Firm("StartUp Boost", DateTime.Today.AddYears(-4), "Marketing", "Olivia White", 180, "London, Baker Street"), new Firm("Food Launch", DateTime.Today.AddYears(-1), "Marketing", "Daniel Black", 120, "London, King Road"), new Firm("White Food Lab", DateTime.Today.AddDays(-123), "IT", "Emily Black", 80, "Kyiv, Podil"), new Firm("Digital Spark", DateTime.Today.AddYears(-3), "IT", "Lionel Brown", 350, "London, Oxford Street"), new Firm("Green Future", DateTime.Today.AddYears(-2).AddDays(-1), "Consulting", "George White", 40, "Warsaw, Center Street") }; }
        private static void Show(string title, IEnumerable<Firm> firms) { Console.WriteLine("\n--- " + title + " ---"); foreach (Firm firm in firms) Console.WriteLine(firm); }
    }
}
