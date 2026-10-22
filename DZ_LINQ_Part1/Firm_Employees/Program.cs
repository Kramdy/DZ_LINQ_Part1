using System;
using System.Linq;

namespace FirmEmployees
{
    internal class Employee
    {
        public string FullName { get; set; } public string Position { get; set; } public string Phone { get; set; } public string Email { get; set; } public decimal Salary { get; set; }
        public Employee(string name, string position, string phone, string email, decimal salary) { FullName = name; Position = position; Phone = phone; Email = email; Salary = salary; }
        public override string ToString() { return FullName + " | " + Position + " | " + Phone + " | " + Email + " | " + Salary; }
    }
    internal class Firm { public string Name { get; set; } public Employee[] Employees { get; set; } public Firm(string name, Employee[] employees) { Name = name; Employees = employees; } }
    internal class Program
    {
        private static void Main()
        {
            // Задание 3
            // Добавьте в фирму сотрудников: ФИО, должность, телефон, Email, зарплата.
            // Для массива сотрудников получите: всех конкретной фирмы; с зарплатой выше
            // заданной; менеджеров всех фирм; телефоны с 23; Email с di; имя Lionel.
            Firm[] firms = CreateFirms();
            string firmName = "StartUp Boost"; decimal minimumSalary = 3000;
            Show("Сотрудники " + firmName, from firm in firms where firm.Name == firmName from employee in firm.Employees select employee);
            Show("С зарплатой больше " + minimumSalary, from firm in firms where firm.Name == firmName from employee in firm.Employees where employee.Salary > minimumSalary select employee);
            Show("Все менеджеры", from firm in firms from employee in firm.Employees where employee.Position == "Manager" select employee);
            Show("Телефон начинается с 23", from firm in firms from employee in firm.Employees where employee.Phone.StartsWith("23") select employee);
            Show("Email начинается с di", from firm in firms from employee in firm.Employees where employee.Email.StartsWith("di") select employee);
            Show("Имя Lionel", from firm in firms from employee in firm.Employees where employee.FullName.StartsWith("Lionel ") select employee);
            Console.ReadKey();
        }
        private static Firm[] CreateFirms() { return new Firm[] { new Firm("StartUp Boost", new Employee[] { new Employee("Lionel Stone", "Manager", "231111111", "lionel@startup.com", 4200), new Employee("Diana Reed", "Marketing Specialist", "221111111", "diana@startup.com", 2900) }), new Firm("Food Launch", new Employee[] { new Employee("Daniel Black", "Manager", "239999999", "dblack@food.com", 3600), new Employee("Ira White", "Developer", "501111111", "irawhite@food.com", 3300) }) }; }
        private static void Show(string title, System.Collections.Generic.IEnumerable<Employee> employees) { Console.WriteLine("\n--- " + title + " ---"); foreach (Employee employee in employees) Console.WriteLine(employee); }
    }
}
