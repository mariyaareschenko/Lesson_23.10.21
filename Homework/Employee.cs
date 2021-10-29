using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    abstract class Employee
    {
        private string name;
        private Employee head;
        private List<Task> tasks = new List<Task>();
        private Guid id;
        private double fine = 0;
        private const int constant_fine = 500;
        public Employee(string name, Employee head)
        {
            this.name = name;
            this.head = head;
            id = Guid.NewGuid();
        }
        public Employee(string name)
        {
            this.name = name;
            id = Guid.NewGuid();
        }
        public static void GiveTask(List<Employee> employees)
        {
            Console.WriteLine("Кто дает задачу:");
            string name_head = Console.ReadLine();
            Type type_head = null;
            bool isFound = false;
            foreach (var worker in employees)
            {
                if (worker.name.Equals(name_head) && !(worker is Developer) && !(worker is SystemEmploye))
                {
                    type_head = worker.GetType();
                    isFound = true;
                    Console.WriteLine("Мы нашли этого работника");
                    worker.PrintInfo();
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Работник не был найден");
            }
            Console.WriteLine("Кому нужно передать задачу");
            string name = Console.ReadLine();
            isFound = false;
            foreach (var employee in employees)
            {
                if (name.Equals(employee.name) && (employee.head.GetType() == type_head) && !(employee is Boss) && (employee.tasks.Count<2))
                {
                    Console.WriteLine("Задача может быть передана");
                    Console.WriteLine("Согласен ли работник выполнить задачу: да/нет");
                    string access = Console.ReadLine().ToLower();
                    if (access.Equals("нет"))
                    {
                        Console.WriteLine("Сотрудник получил штраф");//Штраф и предупреждение
                        employee.fine += constant_fine;
                    }
                    else
                    {
                        employee.tasks.Add(Task.NewTask());
                        isFound = true;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Задача не может быть передана/ работник не найден");
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Имя работника {this.name} ID работника: {this.id}. Штраф: {this.fine} рублей");
        }
    }
}
