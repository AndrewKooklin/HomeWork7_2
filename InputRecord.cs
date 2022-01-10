using System;
using System.IO;

namespace HomeWork7_2
{
    public static class InputRecord
    {
        /// <summary>
        /// Ввод данных о сотруднике
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] CreateRecord(string path)
        {
            Employee emp = new Employee();

            Console.WriteLine("Введите ID сотрудника");
            emp.id = Console.ReadLine();

            emp.dateCreate = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

            Console.WriteLine("Введите Ф.И.О.");
            emp.fullName = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            emp.age = Console.ReadLine();

            Console.WriteLine("Введите рост в см");
            emp.height = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            emp.dateOfBirth = Console.ReadLine();

            Console.WriteLine("Введите место рождения");
            emp.placeOfBirth = "Город " + Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Запись в файле {Path.GetFileName(path)} создана");

            return emp.Record();

        }
    }
}
