using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork7_2
{
    public static class DeleteRecord
    {
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="path"></param>
        /// <param name="control"></param>
        public static void Delete(string path)
        {
            string[] arr = Read.ReadAllLines(path);

            int control = ControlInput.Input();

            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!arr[i].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        if ((i == arr.Length - 1) && !arr[^1].StartsWith(Convert.ToInt32(control) + "#"))
                        {
                            Console.WriteLine("В файле нет такой записи");
                        }
                        continue;
                    }
                    else if (arr[i].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        arr[i] = null;

                        Write.WriteAll(path, arr);

                        Console.WriteLine($"Запись с номером {control} удалена");
                        break;
                    }
                }               
            }
        }
    }
}
