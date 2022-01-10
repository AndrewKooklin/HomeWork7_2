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
        /// <param name="path"></param>
        /// <param name="key"></param>
        public static void Operation(string path, char key)
        {
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

                Console.WriteLine();

                switch (input)
                {
                    case '1':
                        {
                            PrintRecord.Print(Read.ReadAllText(path));
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '2':
                        {
                            PrintRecord.Print(Read.ReadRecord(path));
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '3':
                        {
                            Write.WriteOneRecord(path, InputRecord.CreateRecord(path));
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '4':
                        {
                            DeleteRecord.Delete(path);
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '5':
                        {
                            UpdateRecord.Update(path);
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '6':
                        {
                            PrintRecord.Print(SelectByDate.SelectDate(path));
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '7':
                        {
                            Write.WriteAll(path, SortedByDate.Sorted(path));
                            key = ContinueProgramm.Continue();
                            break;
                        }
                    case '8':
                        {
                            Console.WriteLine("Программа завершена");
                            key = 'n';
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введите цифру от 1 до 8 или букву");
                            break;
                        }
                }
            } while (char.ToLower(key) == 'y');
        }
    }
}

