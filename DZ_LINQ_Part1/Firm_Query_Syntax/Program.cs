using System;
using System.Linq;

namespace FirmQuerySyntax
{
    internal class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string Director { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime date, string profile, string director, int employees, string address)
        { Name = name; FoundationDate = date; BusinessProfile = profile; Director = director; EmployeesCount = employees; Address = address; }
        public override string ToString() { return Name + " | " + BusinessProfile + " | директор: " + Director + " | сотрудников: " + EmployeesCount + " | " + Address; }
    }

    internal class Program
    {
        private static void Main()
        {
            // Задание 1
            // Реализуйте пользовательский тип Фирма: название, дата основания, профиль
            // бизнеса, ФИО директора, количество сотрудников, адрес. Для массива фирм
            // используйте синтаксис запросов LINQ: все фирмы; Food в названии; маркетинг;
            // маркетинг или IT; больше 100; от 100 до 300; Лондон; директор White;
            // старше двух лет; основаны 123 дня назад; директор Black и White в названии.
            Firm[] firms = CreateFirms();
            Show("Все фирмы", from firm in firms select firm);
            Show("Food в названии", from firm in firms where firm.Name.Contains("Food") select firm);
            Show("Маркетинг", from firm in firms where firm.BusinessProfile == "Marketing" select firm);
            Show("Маркетинг или IT", from firm in firms where firm.BusinessProfile == "Marketing" || firm.BusinessProfile == "IT" select firm);
            Show("Больше 100 сотрудников", from firm in firms where firm.EmployeesCount > 100 select firm);
            Show("От 100 до 300 сотрудников", from firm in firms where firm.EmployeesCount >= 100 && firm.EmployeesCount <= 300 select firm);
            Show("Фирмы в Лондоне", from firm in firms where firm.Address.Contains("London") select firm);
            Show("Директор White", from firm in firms where firm.Director.EndsWith("White") select firm);
            Show("Основаны больше двух лет назад", from firm in firms where firm.FoundationDate < DateTime.Today.AddYears(-2) select firm);
            Show("Основаны 123 дня назад", from firm in firms where (DateTime.Today - firm.FoundationDate).Days == 123 select firm);
            Show("Директор Black и White в названии", from firm in firms where firm.Director.EndsWith("Black") && firm.Name.Contains("White") select firm);
            Console.ReadKey();
        }

        private static Firm[] CreateFirms()
        {
            return new Firm[]
            {
                new Firm("StartUp Boost", DateTime.Today.AddYears(-4), "Marketing", "Olivia White", 180, "London, Baker Street"),
                new Firm("Food Launch", DateTime.Today.AddYears(-1), "Marketing", "Daniel Black", 120, "London, King Road"),
                new Firm("White Food Lab", DateTime.Today.AddDays(-123), "IT", "Emily Black", 80, "Kyiv, Podil"),
                new Firm("Digital Spark", DateTime.Today.AddYears(-3), "IT", "Lionel Brown", 350, "London, Oxford Street"),
                new Firm("Green Future", DateTime.Today.AddYears(-2).AddDays(-1), "Consulting", "George White", 40, "Warsaw, Center Street")
            };
        }

        private static void Show(string title, IQueryable<Firm> query) { }
        private static void Show(string title, System.Collections.Generic.IEnumerable<Firm> firms)
        {
            Console.WriteLine("\n--- " + title + " ---");
            foreach (Firm firm in firms) Console.WriteLine(firm);
        }
    }
}
