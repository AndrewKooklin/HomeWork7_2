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
                foreach (var word in words)
                {
                    Console.WriteLine($"{word} ");
                }
            }
            
        }
        /// <summary>
        /// Печать одгой записи
        /// </summary>
        /// <param name="words"></param>
        public static void PrintOneRecord(string[] words)
        {
            if (words != null)
            {
                foreach (var word in words)
                {
                    Console.Write($"{word} ");
                }
            }
        }
    }
}
