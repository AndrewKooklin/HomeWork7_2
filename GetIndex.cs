using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class GetIndex
    {
        /// <summary>
        /// Получение id записи
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="control"></param>
        /// <returns>Возвращает номер записи</returns>
        public static int GetIndexLine(string[] lines, int control)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(control.ToString() + "#"))
                {
                    int index = i;

                    return index;
                }
            }
            return 0;
        }
    }
}
