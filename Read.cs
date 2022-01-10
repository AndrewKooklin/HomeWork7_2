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
        public static string[] ReadAllText(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] separator = { '#', '\r' };

                string[] words = sr.ReadToEnd().Split(separator);

                if (words == null || words.Length <= 0 || words[0] == "")
                {
                    Console.WriteLine("В файле нет записей");

                    return null;
                }
                return words;
            }

        }

        /// <summary>
        /// Чтение выбранной записи из файла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static string[] ReadRecord(string path)
        {
            string[] arr = Read.ReadAllLines(path);

            int control = ControlInput.Input();

            if (arr == null || control == 0)
            {
                return null;
            }

            string[] words;

            for (int i = 0; i < arr.Length; i++)
            {

                if (!arr[i].StartsWith(Convert.ToInt32(control) + "#") && !arr[i].StartsWith("\n" + Convert.ToInt32(control) + "#"))
                {
                    if ((i == arr.Length - 1) && !arr[^1].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        Console.WriteLine("В файле нет такой записи");
                        return null;
                    }
                    continue;
                }
                else if ( arr[i].StartsWith(Convert.ToInt32(control) + "#") || arr[i].StartsWith("\n" + Convert.ToInt32(control) + "#") )
                {
                    words = arr[i].Split('#');

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
                char[] separator = { '\r' };

                string[] arr = sr.ReadToEnd().Split(separator);

                sr.Close();

                if (arr.Length <= 0 || arr == null || arr[0] == "")
                {
                    Console.WriteLine("В файле нет записей");
                    return null;
                }

                return arr;
            }
        }
    }
}
