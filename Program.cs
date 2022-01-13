using System;

namespace HomeWork7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Employees.txt";

            CreateFile.Creation(path);

            Console.WriteLine("\nПрограмма работы с записями о сотрудниках");

            string[] allLinesRecords = Read.ReadAllLines(path);

            ChooseAction.Operation(allLinesRecords, path);

            Console.ReadLine();
        }
    }
}
