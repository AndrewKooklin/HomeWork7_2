using System;

namespace HomeWork7_2
{
    public static class DeleteRecord
    {
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="path"></param>
        /// <param name="control"></param>
        public static string[] Delete(string[] allLinesRecords)
        {
            if (allLinesRecords != null)
            {
                int control = ControlInput.Input();

                for (int i = 0; i < allLinesRecords.Length; i++)
                {
                    if (!allLinesRecords[i].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        if ((i == allLinesRecords.Length - 1) && !allLinesRecords[^1].StartsWith(Convert.ToInt32(control) + "#"))
                        {
                            Console.WriteLine("В файле нет такой записи");
                        }
                        continue;
                    }
                    else if (allLinesRecords[i].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        allLinesRecords[i] = "";

                        Console.WriteLine($"Запись с номером {control} удалена");
                        break;
                    }
                }               
            }
            return allLinesRecords;
        }
    }
}
