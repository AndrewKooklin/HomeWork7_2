using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    
    public static class DeleteEmpty
    {
        /// <summary>
        /// Перезапись массива без пустых элементов
        /// </summary>
        public static string[] Rewrite(string[] arr)
        {
            int counter = 0; // кол-во пустых элементов в массиве

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "" || arr[i] == null || arr[i] == "\n")
                {
                    counter++;
                }
                else continue;
            }

            if(counter == arr.Length)
            {
                return null;
            }
            string[] newarr = new string[arr.Length - counter];

            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "" && arr[i] != null)
                {
                    newarr[j] = arr[i].Replace("\n", "");
                    j++;
                }
                else continue;
            }
            return newarr;
        }
    }
}
