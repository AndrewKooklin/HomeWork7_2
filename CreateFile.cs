using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork7_2
{

    public static class CreateFile
    {   /// <summary>
        /// Создание файла
        /// </summary>
        public static void Creation(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
    }
}
