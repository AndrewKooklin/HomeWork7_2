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
            if(allLinesRecords == null)
            {
                Console.WriteLine("В файле нет записей");
                return null;
            }

            string[] newlines = new string[allLinesRecords.Length];

            if (allLinesRecords != null)
            {

                Console.WriteLine("Введите начальную дату");

                DateTime dataStart = Convert.ToDateTime(Console.ReadLine()).Date;

                Console.WriteLine("Введите конечную дату");

                DateTime dateFinal = Convert.ToDateTime(Console.ReadLine()).Date;



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

                    if (dataStart <= dateArr[i] && dateArr[i] <= dateFinal)
                    {
                        newlines[i] = allLinesRecords[i];
                    }
                    else
                    {
                        newlines[i] = null;
                    }
                }

                if (newlines == null)
                {
                    Console.WriteLine("\nВ файле нет таких записей");
                    return null;
                }

            }
            return newlines;
        }
    }
}
