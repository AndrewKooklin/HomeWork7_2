using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class ControlInput
    {
        /// <summary>
        /// Проверка вводимой строки на число
        /// </summary>
        /// <returns></returns>
        public static int Input()
        {
            Console.WriteLine("Введите номер записи");
            string numberRecord = Console.ReadLine();

            bool result = Int32.TryParse(numberRecord, out int control);

            if (control == 0 || !result)
            {
                return 0;
            }
            else if (result)
            {
                return control;
            }
            return 0;
        }
    }
}
