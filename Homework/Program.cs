using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Boss("Борис"));
            employees.Add(new HelperOfBoss("О Ильхам", employees[0]));
            employees.Add(new MainDeveloper("Сергей", employees[1]));
            employees.Add(new MainSystemEmployee("Ильшат", employees[1]));
            employees.Add(new HelperOfDeveloper("Ляйсан", employees[2]));
            employees.Add(new HelperOfSystemEmloyee("Иваныч",employees[3]));
            employees.Add(new SystemEmploye("Илья", employees[5]));
            employees.Add(new SystemEmploye("Витя", employees[5]));
            employees.Add(new SystemEmploye("Женя", employees[5]));
            employees.Add(new Developer("Дина", employees[4]));
            employees.Add(new Developer("Марат", employees[4]));
            employees.Add(new Developer("Ильдар", employees[4]));
            employees.Add(new Developer("Антон", employees[4]));
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите команду 'Добавить', чтоды добавить задачу/ 'Выйти', чтобы выйти из программы");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "добавить":
                        Employee.GiveTask(employees);
                        break;
                    case "выйти":
                        flag = false;
                        break;
                }
            }
        }
    }
}
