using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class SortedByDate
    {
        /// <summary>
        /// Сортировка по полю "дата"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] Sorted(string path)
        {
            string[] lines = Read.ReadAllLines(path);

            if (lines.Length <= 0 && lines == null || lines[0] == "")
            {
                return null;
            }

            DateTime[] dateArr = new DateTime[lines.Length];

            for (int i = 0; i < dateArr.Length; i++)
            {
                string[] words = lines[i].Split('#');

                if (words == null || words[0] == "" || words[0] == "\n")
                {
                    continue;
                }
                else dateArr[i] = Convert.ToDateTime(words[1]);
            }

            

            Console.WriteLine("\nСортировка записей по дате" +
                "\n введите цифру :" + "\n1 - для сортировке по возрастанию даты" +
                "\n2 - для сортировки по убыванию даты");

            string numberSort = Console.ReadLine();

            DateTime temp;

            if (numberSort == "1")
            {                
                for (int i = 0; i < dateArr.Length - 1; i++)
                {
                    for (int j = i + 1; j < dateArr.Length; j++)
                    {
                        if (dateArr[i] > dateArr[j])
                        {
                            temp = dateArr[i];
                            dateArr[i] = dateArr[j];
                            dateArr[j] = temp;
                        }
                    }
                }
                Console.WriteLine("Записи отсортированы по возрастанию даты создания");
            }
            else if(numberSort == "2")
            {
                for (int i = 0; i < dateArr.Length - 1; i++)
                {
                    for (int j = i + 1; j < dateArr.Length; j++)
                    {
                        if (dateArr[i] < dateArr[j])
                        {
                            temp = dateArr[i];
                            dateArr[i] = dateArr[j];
                            dateArr[j] = temp;
                        }
                    }
                }
                Console.WriteLine("Записи отсортированы по убыванию даты создания");
            }

            string[] newarr = new string[lines.Length];

            for (int i = 0; i < dateArr.Length; i++)
            {
                for(int j = 0; j < lines.Length; j++)
                {
                    if (lines[j].Contains(dateArr[i].ToString("dd.MM.yyyy hh:mm")))
                    {
                        newarr[i] = lines[j];
                    }
                }
            }

            return newarr;
        }

    }
}
