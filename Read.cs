using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork7_2
{
    public static class Read
    {
        /// <summary>
        /// Чтение всего файла по словам в массив
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //public static string[] ReadAllText(string path)
        //{
        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        char[] separator = { '#', '\r' };

        //        string[] words = sr.ReadToEnd().Split(separator);

        //        if (words == null || words.Length <= 0)
        //        {
        //            Console.WriteLine("В файле нет записей");

        //            return null;
        //        }
        //        return words;
        //    }

        //}

        /// <summary>
        /// Чтение выбранной записи из файла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static string[] ReadRecord(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В файле нет записей");
                return null;
            }

            int control = ControlInput.Input();
            if(control == 0)
            {
                return null;
            }

            string[] words;

            for (int i = 0; i < allLinesRecords.Length; i++)
            {

                if (!allLinesRecords[i].StartsWith(Convert.ToInt32(control) + "#") && !allLinesRecords[i].StartsWith("\n" + Convert.ToInt32(control) + "#"))
                {
                    if ((i == allLinesRecords.Length - 1) && !allLinesRecords[^1].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        Console.WriteLine("В файле нет такой записи");
                        return null;
                    }
                    continue;
                }
                else if (allLinesRecords[i].StartsWith(Convert.ToInt32(control) + "#") || allLinesRecords[i].StartsWith("\n" + Convert.ToInt32(control) + "#"))
                {
                    words = allLinesRecords[i].Split('#');

                    return words;
                }

            }
            return null;
        }

        /// <summary>
        /// Чтение файла построчно в массив
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] separator = { '\n' };

                string[] arr = sr.ReadToEnd().Split(separator);

                sr.Close();

                int counter = 0; // кол-во пустых элементов в массиве

                if (arr == null)
                {
                    Console.WriteLine("В файле нет записей");
                    return null;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "" || arr[i] == null || arr[i] == "\r")
                    {
                        counter++;
                    }
                    else continue;
                }

                if (counter == arr.Length)
                {
                    Console.WriteLine("В файле нет записей");
                    return null;
                }
                string[] newarr = new string[arr.Length - counter];


                for (int j = 0; j < newarr.Length; j++)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == "" || arr[i] == null || arr[i] == "\r")
                        {
                            continue;
                        }
                        else
                        {
                            newarr[j] = arr[i].Replace("\r", "");
                            //j++;
                        }
                    }
                }
                return newarr;
            }
        }
    }
}
