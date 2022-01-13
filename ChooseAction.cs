using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class ChooseAction
    {
        /// <summary>
        /// Выбор пунктов основного меню
        /// </summary>
        public static void Operation(string[] allLinesRecords, string path)
        {
            char key;

            do
            {

                Console.WriteLine("\nВведите цифру :" +
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
                            PrintRecord.PrintAllLines(Read.ReadAllLines(path));
                            break;
                        }
                    case '2':
                        {
                            PrintRecord.PrintOneRecord(Read.ReadRecord(allLinesRecords));
                            break;
                        }
                    case '3':
                        {
                            Write.WriteOneRecord(path, InputRecord.CreateRecord());
                            break;
                        }
                    case '4':
                        {
                            Write.WriteAllLines(path, DeleteRecord.Delete(allLinesRecords));
                            break;
                        }
                    case '5':
                        {
                            UpdateRecord.Update(allLinesRecords, path);
                            break;
                        }
                    case '6':
                        {
                            PrintRecord.PrintAllLines(SelectByDate.SelectDate(allLinesRecords));
                            break;
                        }
                    case '7':
                        {
                            Write.WriteAllLines(path, SortedByDate.Sorted(allLinesRecords));
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

            } while ( key != '8');
        }
    }
}

