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
        public static string[] SelectDate(string path)
        {
            Console.WriteLine("Введите начальную дату");

            DateTime dataStart = Convert.ToDateTime(Console.ReadLine()).Date;

            Console.WriteLine("Введите конечную дату");

            DateTime dateFinal = Convert.ToDateTime(Console.ReadLine()).Date;

            string[] lines = Read.ReadAllLines(path);

            if (lines.Length <= 0 && lines == null || lines[0] == "")
            {
                return null;
            }

            string[] newlines = new string[lines.Length];

            DateTime[] dateArr = new DateTime[lines.Length];

            for (int i = 0; i < dateArr.Length; i++)
            {
                string[] words = lines[i].Split('#');

                if (words == null || words[0] == "" || words[0] == "\n")
                {
                    newlines[i] = null;
                    continue;
                }
                else dateArr[i] = Convert.ToDateTime(words[1]).Date;

                if (dataStart <= dateArr[i] && dateArr[i] <= dateFinal)
                {
                    newlines[i] = lines[i];
                }
                else
                {
                    newlines[i] = null;
                }
            }

            newlines = DeleteEmpty.Rewrite(newlines);

            if (newlines == null)
            {
                Console.WriteLine("\nВ файле нет таких записей");
                return null;
            }
            return newlines;
        }
    }
}
