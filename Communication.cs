using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class Communication
    {
        /// <summary>
        /// Выбор пунктов основного меню
        /// </summary>
        public static void Operation(string[] allLinesRecords, string path)
        {
            char key;

            do
            {

                Console.WriteLine("\n Введите цифру :" +
                    "\n 1 - для просмотра файла" +
                    "\n 2 - для просмотра записи" +
                    "\n 3 - для создания записи" +
                    "\n 4 - для удаления записи" +
                    "\n 5 - для редактирования записи" +
                    "\n 6 - для чтения записей в выбранном доапазоне дат" +
                    "\n 7 - для сортировки записи по возрастанию и убыванию дат" +
                    "\n 8 - для выхода из программы");

                char input = Console.ReadKey().KeyChar;

                key = input;

                Console.WriteLine();

                switch (input)
                {
                    case '1':
                        {
                            FileMethods.PrintAllLines(FileMethods.ReadAllLines(path));
                            break;
                        }
                    case '2':
                        {
                            FileMethods.PrintOneRecord(FileMethods.ReadRecord(allLinesRecords));
                            break;
                        }
                    case '3':
                        {
                            FileMethods.WriteOneRecord(path, Communication.CreateRecord());
                            break;
                        }
                    case '4':
                        {
                            FileMethods.WriteAllLines(path, FileMethods.Delete(allLinesRecords));
                            break;
                        }
                    case '5':
                        {
                            FileMethods.Update(allLinesRecords, path);
                            break;
                        }
                    case '6':
                        {
                            FileMethods.PrintAllLines(FileMethods.SelectDate(allLinesRecords));
                            break;
                        }
                    case '7':
                        {
                            FileMethods.WriteAllLines(path, FileMethods.Sorted(allLinesRecords));
                            break;
                        }
                    case '8':
                        {
                            Console.WriteLine("Программа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введите цифру от 1 до 8");
                            break;
                        }
                }

            } while (key != '8');
        }

        /// <summary>
        /// Проверка вводимой строки на число
        /// </summary>
        /// <returns></returns>
        public static int Input()
        {
            Console.WriteLine("Введите номер записи");
            string numberRecord = Console.ReadLine();

            bool result = Int32.TryParse(numberRecord, out int control);

            if (control == 0 || !result)
            {
                return 0;
            }
            else if (result)
            {
                return control;
            }
            return 0;
        }

        /// <summary>
        /// Ввод данных о сотруднике
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] CreateRecord()
        {
            FileMethods.Employee emp = new FileMethods.Employee();

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
