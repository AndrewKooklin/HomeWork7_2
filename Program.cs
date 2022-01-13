using System;

namespace HomeWork7_2
{
    class Program
    {
        static void Main()
        {
            string path = @"Employees.txt";

            FileMethods.Creation(path);

            Console.WriteLine("\n Программа работы с записями о сотрудниках");

            string[] allLinesRecords = FileMethods.ReadAllLines(path);

            Communication.Operation(allLinesRecords, path);

            Console.ReadLine();
        }
    }
}
