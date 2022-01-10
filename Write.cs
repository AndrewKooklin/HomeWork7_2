using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork7_2
{
    public static class Write
    {
        /// <summary>
        /// Запись добавленного сотрудника в конец файла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="array"></param>
        public static void WriteOneRecord(string path, byte[] array)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                fs.Write(array, 0, array.Length);
            }
        }

        /// <summary>
        /// Запись всех строк в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        public static void WriteAll(string path, string[] arr)
        {
            string[] newarr = DeleteEmpty.Rewrite(arr);

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < newarr.Length; i++)
                {
                        sw.WriteLine(newarr[i]);                  
                }
            }
        }
    }
}
