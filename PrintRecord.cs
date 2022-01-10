using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class PrintRecord
    {
        /// <summary>
        /// Печать в консоль
        /// </summary>
        /// <param name="words"></param>
        public static void Print(string[] words)
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
