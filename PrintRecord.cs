using System;

namespace HomeWork7_2
{
    public static class PrintRecord
    {
        /// <summary>
        /// Печать в консоль
        /// </summary>
        /// <param name="words"></param>
        public static void PrintAllLines(string[] words)
        {
            if (words != null)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        words[i] = words[i].Replace("#", " ");

                        Console.WriteLine(words[i]);
                    }

                }
            }
        }
        /// <summary>
        /// Печать одгой записи
        /// </summary>
        /// <param name="words"></param>
        public static void PrintOneRecord(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == null)
                {
                    continue;
                }
                else
                {
                    Console.Write($"{words[i]} ");
                }
            }

        }
    }
}
