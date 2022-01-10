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
        public static void Update(string path)
        {
            int control = ControlInput.Input();

            string[] lines = Read.ReadAllLines(path);

            int index = GetIndex.GetIndexLine(lines, control);

            string[] words = Read.ReadRecord(path);

            PrintRecord.Print(words);

            if (words != null)
            {
                Employee emp = new Employee();
                emp.id = words[0];
                emp.dateCreate = words[1];
                emp.fullName = words[2];
                emp.age = words[3];
                emp.height = words[4];
                emp.dateOfBirth = words[5];
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
                                lines[index] = Encoding.UTF8.GetString(emp.Record());
                                Write.WriteAll(path, lines);
                                Console.WriteLine("Поле \"Ф.И.О.\" изменено");
                                break;
                            }
                        case '2':
                            {
                                Console.WriteLine("Введите возраст :");
                                emp.age = Console.ReadLine();
                                lines[index] = Encoding.UTF8.GetString(emp.Record());
                                Write.WriteAll(path, lines);
                                Console.WriteLine("Поле \"возраст\" изменено");
                                break;
                            }
                        case '3':
                            {
                                Console.WriteLine("Введите рост :");
                                emp.height = Console.ReadLine();
                                lines[index] = Encoding.UTF8.GetString(emp.Record());
                                Write.WriteAll(path, lines);
                                Console.WriteLine("Поле \"рост\" изменено");
                                break;
                            }
                        case '4':
                            {
                                Console.WriteLine("Введите дату рождения :");
                                emp.dateOfBirth = Console.ReadLine();
                                lines[index] = Encoding.UTF8.GetString(emp.Record());
                                Write.WriteAll(path, lines);
                                Console.WriteLine("Поле \"дата рождения\" изменено");
                                break;
                            }
                        case '5':
                            {
                                Console.WriteLine("Введите место рождения :");
                                emp.placeOfBirth = Console.ReadLine();
                                lines[index] = Encoding.UTF8.GetString(emp.Record());
                                Write.WriteAll(path, lines);
                                Console.WriteLine("Поле \"место рождения\" изменено");
                                break;
                            }
                        default:
                            Console.WriteLine("Введите цифру от 1 до 5 :");
                            break;

                    }
                }
                while (Convert.ToInt32(char.ToLower(input)) > 0 && Convert.ToInt32(char.ToLower(input)) < 6);
            }
        }
    }
}
