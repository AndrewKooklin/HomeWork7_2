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
        public static byte[] CreateRecord()
        {
            Employee emp = new Employee();

            do
            {
                Console.WriteLine("Введите ID сотрудника (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.id);

                if (input)
                {
                    break;
                }
                else 
                { 
                    Console.WriteLine("Вы ввели не число");
                }
            }
            while (true);

            emp.dateCreate = DateTime.Now;

            Console.WriteLine("Введите Ф.И.О.");
            emp.fullName = Console.ReadLine();

            do
            {
                Console.WriteLine("Введите возраст (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.age);

                if (input)
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Введите рост в см (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.height);

                if (input)
                {
                    break;
                }
                else
                { 
                    Console.WriteLine("Вы ввели не число"); 
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Введите дату рождения в числовом формате dd.MM.yyyy");

                bool input = DateTime.TryParse(Console.ReadLine(), out emp.dateOfBirth);

                if (input)
                {
                    break;
                }
                else
                { 
                    Console.WriteLine("Вы ввели неверный формат");
                }
            }
            while (true);

            Console.WriteLine("Введите место рождения");
            emp.placeOfBirth = "Город " + Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Запись в файле создана");

            return emp.Record();

        }
    }
}
