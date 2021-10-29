using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_23._10._21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            BankAccount bankAccount_1 = new BankAccount();
            Console.WriteLine("Введите номер аккаунта");
            long number;
            while(!long.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите тип аккаунта");
            string type = Console.ReadLine();
            Console.WriteLine("Введите баланс банковского счета");
            decimal balanse;
            while(!decimal.TryParse(Console.ReadLine(), out balanse))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            bankAccount_1.Number = number;
            bankAccount_1.Type = type;
            bankAccount_1.Balance = balanse;
            bankAccount_1.PrintValues();
            BankAccount bankAccount_2 = new BankAccount();
            Console.WriteLine("Введите номер аккаунта");
            while (!long.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите тип аккаунта");
            type = Console.ReadLine();
            Console.WriteLine("Введите баланс банковского счета");
            while (!decimal.TryParse(Console.ReadLine(), out balanse))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            bankAccount_2.Number = number;
            bankAccount_2.Type = type;
            bankAccount_2.Balance = balanse;
            bankAccount_2.PrintValues();
            Console.WriteLine("Введите сумму, которую нужно перевести с первого счета на второй");
            int sum1;
            while (!int.TryParse(Console.ReadLine(),out sum1))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (sum1 > bankAccount_1.Balance)
            {
                Console.WriteLine("Невозможно осуществить перевод");
            }
            else
            {
                bankAccount_1.MoneyTransfer(bankAccount_2, sum1);
                Console.WriteLine($"Баланс на первом аккаунте: {bankAccount_1.Balance}");
                Console.WriteLine($"Баланс на втором аккаунте: {bankAccount_2.Balance}");
            }
            Console.WriteLine("Введите сумму, которую нужно перевести со второго счета на первый");
            int sum2;
            while (!int.TryParse(Console.ReadLine(), out sum2))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (sum2 > bankAccount_2.Balance)
            {
                Console.WriteLine("Невозможно осуществить перевод");
            }
            else
            {
                bankAccount_2.MoneyTransfer(bankAccount_1, sum2);
                Console.WriteLine($"Баланс на втором аккаунте: {bankAccount_2.Balance}");
                Console.WriteLine($"Баланс на первом аккаунте: {bankAccount_1.Balance}");
            }

            Console.WriteLine("Упражнение 8.2");
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Console.WriteLine($"Строка наооборот: {ChangeLine(str)}");

            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("Введите название файла");
            string name_file = Console.ReadLine();
            if (File.Exists(name_file))
            {
                string new_file = "newfile.txt";
                File.WriteAllText(new_file, File.ReadAllText(name_file, Encoding.UTF8).ToUpper());
                Console.WriteLine($"Изменения записаны в файл {new_file}");
            }
            else
            {
                Console.WriteLine("Файла с таким именем не существует");
            }

            Console.WriteLine("Упражнение 8.4");
            Console.WriteLine("Введите строку");
            str = Console.ReadLine();
            Console.WriteLine(IsFormatTable(str));

            Console.WriteLine("Домашнее задание 8.1");
            int count = 0;
            using(StreamReader reader = new StreamReader("student.txt"))
            {
                while(reader.ReadLine() != null)
                {
                    count++;
                }
                reader.Close();
            }
            string str1 = "";
            using (StreamReader reader = new StreamReader("student.txt"))
            {
                for(int i = 0; i < count; i++)
                {
                    str1 += reader.ReadLine() + "\n";
                }
            }
            GetMail(ref str1);

            Console.WriteLine("Домашнее задание 8.2");
            List<Song> songs = new List<Song>();
            songs.Add(new Song("Улицы ждали", "ZOLOTO"));
            songs.Add(new Song("Улицы ждали", "ZOLOTO"));
            songs.Add(new Song("Видели ночь", "Кино"));
            songs.Add(new Song("Will he", "Joji"));
            foreach(var song in songs)
            {
                Console.WriteLine(Song.Title(song));
            }
            Song.Search(songs);
            Console.ReadKey();
        }
        static string ChangeLine(string str)
        {
            string old_str = str;
            var new_str = new StringBuilder();
            for(int i = old_str.Length-1; i >= 0; i--)
            {
                new_str.Append(old_str[i]);
            }
            return new_str.ToString();
        }
        static bool IsFormatTable(object a)
        {
            if (a is IFormattable)
            {

                Console.WriteLine(a as IFormattable); 
                return true;
            }
            else
            {
                return false;
            }
        }
        static void GetMail(ref string str)
        {
            List<string> emails = new List<string>();
            bool flag = true;
            while(!str.Equals("") && flag)
            {
                int i = 0;
                string new_str = "";
                while(str[i] != '\n')
                {
                    new_str += str[i];
                    i++;
                }
                emails.Add(new_str.Replace(" ", "").Split('#')[1]);
                str = str.Remove(0, str.IndexOf('\n') + 1);
            }
            File.WriteAllLines("email.txt", emails);
        }
    }
}
