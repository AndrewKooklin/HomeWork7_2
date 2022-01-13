using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class UpdateRecord
    {
        /// <summary>
        /// Обновление данных в записи
        /// </summary>
        /// <param name="path"></param>
        public static void Update(string[] allLinesRecords, string path)
        {
            if (allLinesRecords != null)
            {

                int index = GetIndex.GetIndexLine(allLinesRecords, ControlInput.Input());

                string[] words = allLinesRecords[index].Split('#');

                PrintRecord.PrintOneRecord(words);

                if (words != null)
                {
                    Employee emp = new Employee();
                    emp.id = Convert.ToInt32(words[0]);
                    emp.dateCreate = Convert.ToDateTime(words[1]);
                    emp.fullName = words[2];
                    emp.age = Convert.ToInt32(words[3]);
                    emp.height = Convert.ToInt32(words[4]);
                    emp.dateOfBirth = Convert.ToDateTime(words[5]);
                    emp.placeOfBirth = words[6];

                    char input;

                    do
                    {
                        Console.WriteLine("\nКакие данные Вы желаете именить? Введите цифру :" +
                            "\n 1 - для изменения Ф.И.О." +
                            "\n 2 - для изменения возраста" +
                            "\n 3 - для изменения роста" +
                            "\n 4 - для изменения даты рождения" +
                            "\n 5 - для изменения места рождения");

                        input = Console.ReadKey().KeyChar;

                        Console.WriteLine();

                        switch (input)
                        {
                            case '1':
                                {
                                    Console.WriteLine("Введите Ф.И.О. :");
                                    emp.fullName = Console.ReadLine();
                                    Console.WriteLine("Поле \"Ф.И.О.\" изменено");
                                    break;
                                }
                            case '2':
                                {
                                    do
                                    {
                                        Console.WriteLine("Введите возраст (целое число)");

                                        bool check = int.TryParse(Console.ReadLine(), out emp.age);

                                        if (check)
                                        {
                                            break;
                                        }
                                        else { Console.WriteLine("Вы ввели не число"); }
                                    }
                                    while (true);
                                    Console.WriteLine("Поле \"возраст\" изменено");
                                    break;
                                }
                            case '3':
                                {
                                    do
                                    {
                                        Console.WriteLine("Введите рост в см (целое число)");

                                        bool check = int.TryParse(Console.ReadLine(), out emp.age);

                                        if (check)
                                        {
                                            break;
                                        }
                                        else { Console.WriteLine("Вы ввели не число"); }
                                    }
                                    while (true);
                                    Console.WriteLine("Поле \"рост\" изменено");
                                    break;
                                }
                            case '4':
                                {
                                    do
                                    {
                                        Console.WriteLine("Введите дату рождения в числовом формате dd.MM.yyyy");

                                        bool check = DateTime.TryParse(Console.ReadLine(), out emp.dateOfBirth);

                                        if (check)
                                        {
                                            break;
                                        }
                                        else { Console.WriteLine("Вы ввели неверный формат"); }
                                    }
                                    while (true);
                                    Console.WriteLine("Поле \"дата рождения\" изменено");
                                    break;
                                }
                            case '5':
                                {
                                    Console.WriteLine("Введите место рождения :");
                                    emp.placeOfBirth = Console.ReadLine();
                                    Console.WriteLine("Поле \"место рождения\" изменено");
                                    break;
                                }
                            default:
                                Console.WriteLine("Введите цифру от 1 до 5 :");
                                break;

                        }
                    }
                    while (Convert.ToInt32(char.ToLower(input)) > 0 && Convert.ToInt32(char.ToLower(input)) < 6);

                    allLinesRecords[index] = Encoding.UTF8.GetString(emp.Record());

                    Write.WriteAllLines(path, allLinesRecords);

                }
            }
            else
            {
                Console.WriteLine("В файле нет записей");
            }
        }
    }
}
