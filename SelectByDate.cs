using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{

    public static class SelectByDate
    {
        /// <summary>
        /// Выбор записей по дате
        /// </summary>
        public static string[] SelectDate(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В файле нет записей");
                return null;
            }

            string[] newlines = new string[allLinesRecords.Length];

            if (allLinesRecords != null)
            {
                DateTime dataStart;
                DateTime dataFinal;

                do
                {
                    Console.WriteLine("Введите начальную дату в числовом формате dd.MM.yyyy");

                    bool input = DateTime.TryParse(Console.ReadLine(), out dataStart);

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

                do
                {
                    Console.WriteLine("Введите конечную дату в числовом формате dd.MM.yyyy");

                    bool input = DateTime.TryParse(Console.ReadLine(), out dataFinal);

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


                if (allLinesRecords.Length <= 0 || allLinesRecords == null)
                {
                    return null;
                }

                DateTime[] dateArr = new DateTime[allLinesRecords.Length];

                for (int i = 0; i < dateArr.Length; i++)
                {
                    string[] words = allLinesRecords[i].Split('#');

                    if (words == null || words[0] == "" || words[0] == "\n")
                    {
                        newlines[i] = null;
                        continue;
                    }
                    else dateArr[i] = Convert.ToDateTime(words[1]).Date;

                    if (dataStart <= dateArr[i] && dateArr[i] <= dataFinal)
                    {
                        newlines[i] = allLinesRecords[i];
                    }
                    else
                    {
                        newlines[i] = null;
                    }
                }

                bool check = false;

                for (int i = 0; i < newlines.Length; i++)
                {
                    if (newlines[i] != null)
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }                        
                }
                if (check)
                {
                        Console.WriteLine("\nВ файле нет таких записей");
                        return null;
                }
            }
            return newlines;
        }
    }
}
