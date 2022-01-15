using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork7_2
{
    public static class FileMethods
    {
        /// <summary>
        /// Структура "Сотрудник"
        /// </summary>
        public struct Employee
        {
            public int id;

            public DateTime dateCreate;

            public string fullName;

            public int age;

            public int height;

            public DateTime dateOfBirth;

            public string placeOfBirth;

            public Employee(int ID,
                            string FullName, int Age,
                            int Height, DateTime DateOfBirth,
                            string PlaceOfBirth)
            {
                id = ID;

                dateCreate = DateTime.Now;  //ToString("dd.MM.yyyy hh:mm");

                fullName = FullName;

                age = Age;

                height = Height;

                dateOfBirth = DateOfBirth;

                placeOfBirth = PlaceOfBirth;
            }
            public string Record()
            {
                string record = id + "#" + dateCreate.ToString("dd.MM.yyyy hh:mm") + "#" + fullName +
                    "#" + age + "#" + height + "#" + dateOfBirth.ToString("dd.MM.yyyy") +
                    "#" + placeOfBirth + "\r\n";

                return record;
            }
        }

        /// <summary>
        /// Создание файла
        /// </summary>
        public static void Creation(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        public static string[] Delete(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В файле нет записей");
                return null;
            }
            else
            {
                int control = Communication.Input();

                for (int i = 0; i < allLinesRecords.Length; i++)
                {
                    if (!allLinesRecords[i].StartsWith(Convert.ToInt32(control) + "#"))
                    {
                        if ((i == allLinesRecords.Length - 1) && !allLinesRecords[^1].StartsWith(Convert.ToInt32(control) + "#"))
                        {
                            Console.WriteLine("В массиве нет такой записи");
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
            string[] newAllLinesRecords = FileMethods.DeleteEmpty(allLinesRecords);

            return newAllLinesRecords;
        }

        /// <summary>
        /// Обновление данных в записи
        /// </summary>
        /// <param name="path"></param>
        public static string[] Update(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В массиве нет записей");
                return null;
            }
            else if (allLinesRecords != null)
            {

                int index = FileMethods.GetIndexLine(allLinesRecords, Communication.Input());

                if (index < 0)
                {
                    Console.WriteLine("В массиве нет такой записи");
                }
                else
                {
                    string[] words = allLinesRecords[index].Split('#');

                    FileMethods.PrintOneRecord(words);

                    if (words != null)
                    {
                        Employee emp = new Employee();
                        emp.id = Convert.ToInt32(words[0]);
                        emp.dateCreate = Convert.ToDateTime(words[1]);
                        emp.fullName = words[2];
                        emp.age = Convert.ToInt32(words[3]);
                        emp.height = Convert.ToInt32(words[4]);
                        emp.dateOfBirth = Convert.ToDateTime(words[5]);
                        emp.placeOfBirth = words[6];

                        char input;

                        do
                        {
                            Console.WriteLine("\nКакие данные Вы желаете именить? Введите цифру :" +
                                "\n 1 - для изменения Ф.И.О." +
                                "\n 2 - для изменения возраста" +
                                "\n 3 - для изменения роста" +
                                "\n 4 - для изменения даты рождения" +
                                "\n 5 - для изменения места рождения");

                            input = Console.ReadKey().KeyChar;

                            Console.WriteLine();

                            switch (input)
                            {
                                case '1':
                                    {
                                        Console.WriteLine("Введите Ф.И.О. :");
                                        emp.fullName = Console.ReadLine();
                                        Console.WriteLine("Поле \"Ф.И.О.\" изменено");
                                        break;
                                    }
                                case '2':
                                    {
                                        do
                                        {
                                            Console.WriteLine("Введите возраст (целое число)");

                                            bool check = int.TryParse(Console.ReadLine(), out emp.age);

                                            if (check)
                                            {
                                                break;
                                            }
                                            else { Console.WriteLine("Вы ввели не число"); }
                                        }
                                        while (true);
                                        Console.WriteLine("Поле \"возраст\" изменено");
                                        break;
                                    }
                                case '3':
                                    {
                                        do
                                        {
                                            Console.WriteLine("Введите рост в см (целое число)");

                                            bool check = int.TryParse(Console.ReadLine(), out emp.age);

                                            if (check)
                                            {
                                                break;
                                            }
                                            else { Console.WriteLine("Вы ввели не число"); }
                                        }
                                        while (true);
                                        Console.WriteLine("Поле \"рост\" изменено");
                                        break;
                                    }
                                case '4':
                                    {
                                        do
                                        {
                                            Console.WriteLine("Введите дату рождения в числовом формате dd.MM.yyyy");

                                            bool check = DateTime.TryParse(Console.ReadLine(), out emp.dateOfBirth);

                                            if (check)
                                            {
                                                break;
                                            }
                                            else { Console.WriteLine("Вы ввели неверный формат"); }
                                        }
                                        while (true);
                                        Console.WriteLine("Поле \"дата рождения\" изменено");
                                        break;
                                    }
                                case '5':
                                    {
                                        Console.WriteLine("Введите место рождения :");
                                        emp.placeOfBirth = Console.ReadLine();
                                        Console.WriteLine("Поле \"место рождения\" изменено");
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Введите цифру от 1 до 5 :");
                                    break;
                            }
                        }
                        while (Convert.ToInt32(char.ToLower(input)) > 0 && Convert.ToInt32(char.ToLower(input)) < 6);

                        allLinesRecords[index] = emp.Record();

                        return allLinesRecords;
                    }
                }
            }
            return allLinesRecords;
        }

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
            return -1;
        }

        /// <summary>
        /// Чтение выбранной записи из файла
        /// </summary>
        public static string[] ReadRecord(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В массиве нет записей");
                return null;
            }

            int control = Communication.Input();

            int index = FileMethods.GetIndexLine(allLinesRecords, control);

            string[] words;

            if (index < 0)
            {
                Console.WriteLine("В массиве нет такой записи");
                return null;
            }
            else
            {
                words = allLinesRecords[index].Split("#");

                return words;
            }
        }

        /// <summary>
        /// Чтение файла построчно в массив
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] separator = { '\n' };

                string[] arr = sr.ReadToEnd().Split(separator);

                sr.Close();

                int counter = 0; // кол-во пустых элементов в массиве

                if (arr == null)
                {
                    Console.WriteLine("В файле нет записей");
                    return null;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "" || arr[i] == null || arr[i] == "\r")
                    {
                        counter++;
                    }
                    else continue;
                }

                if (counter == arr.Length)
                {
                    Console.WriteLine("В файле нет записей");
                    return null;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i].Replace("\r", "");
                }

                string[] newarr = new string[arr.Length - counter];

                int count = 0;

                for (int j = 0; j < newarr.Length; j++)
                {
                    while (count < arr.Length)
                    {
                        if (arr[count] == "" || arr[count] == null)
                        {
                            count++;
                            continue;
                        }
                        newarr[j] = arr[count];
                        count++;
                        break;
                    }
                }
                return newarr;
            }
        }

        /// <summary>
        /// Перезапись массива без пустых элементов
        /// </summary>
        public static string[] DeleteEmpty(string[] arr)
        {
            int counter = 0; // кол-во пустых элементов в массиве

            if (arr == null)
            {
                return null;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "" || arr[i] == null || arr[i] == "\n")
                {
                    counter++;
                }
                else continue;
            }

            if (counter == arr.Length)
            {
                return null;
            }
            string[] newarr = new string[arr.Length - counter];

            for (int j = 0; j < newarr.Length;)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "" || arr[i] == null || arr[i] == "\n")
                    {
                        continue;
                    }
                    else
                    {
                        newarr[j] = arr[i].Replace("\n", "");
                        j++;
                    }
                }
            }
            return newarr;
        }

        /// <summary>
        /// Запись всех строк в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        public static void WriteAllLines(string path, string[] arr)
        {
            arr = FileMethods.DeleteEmpty(arr);

            if (arr == null)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("");
                }
                Console.WriteLine(" В файле нет записей");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sw.WriteLine(arr[i]);                        
                    }

                    Console.WriteLine("Записи добавлены в файл");
                }
            }
        }

        /// <summary>
        /// Печать в консоль
        /// </summary>
        /// <param name="words"></param>
        public static void PrintAllLines(string[] words)
        {
            words = FileMethods.DeleteEmpty(words);

            if (words == null)
            {
                Console.WriteLine("В массиве нет записей");
            }
            else if (words != null)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        words[i] = words[i].Replace("#", " ");

                        Console.WriteLine(words[i]);
                    }

                }
            }
        }
        /// <summary>
        /// Печать одгой записи
        /// </summary>
        /// <param name="words"></param>
        public static void PrintOneRecord(string[] words)
        {
            if (words != null)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write($"{words[i]} ");
                    }
                }
            }
        }

        /// <summary>
        /// Выбор записей по дате
        /// </summary>
        public static string[] SelectDate(string[] allLinesRecords)
        {
            if (allLinesRecords == null)
            {
                Console.WriteLine("В файле нет записей");
                return null;
            }

            string[] newlines = new string[allLinesRecords.Length];

            if (allLinesRecords != null)
            {
                DateTime dataStart;
                DateTime dataFinal;

                do
                {
                    Console.WriteLine("Введите начальную дату в числовом формате dd.MM.yyyy");

                    bool input = DateTime.TryParse(Console.ReadLine(), out dataStart);

                    if (input)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                }
                while (true);

                do
                {
                    Console.WriteLine("Введите конечную дату в числовом формате dd.MM.yyyy");

                    bool input = DateTime.TryParse(Console.ReadLine(), out dataFinal);

                    if (input)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                }
                while (true);


                if (allLinesRecords.Length <= 0 || allLinesRecords == null)
                {
                    return null;
                }

                DateTime[] dateArr = new DateTime[allLinesRecords.Length];

                for (int i = 0; i < dateArr.Length; i++)
                {
                    string[] words = allLinesRecords[i].Split('#');

                    if (words == null || words[0] == "" || words[0] == "\n")
                    {
                        newlines[i] = null;
                        continue;
                    }
                    else dateArr[i] = Convert.ToDateTime(words[1]).Date;

                    if (dataStart <= dateArr[i] && dateArr[i] <= dataFinal)
                    {
                        newlines[i] = allLinesRecords[i];
                    }
                    else
                    {
                        newlines[i] = null;
                    }
                }

                bool check = false;

                for (int i = 0; i < newlines.Length; i++)
                {
                    if (newlines[i] != null)
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    Console.WriteLine("\nВ файле нет таких записей");
                    return null;
                }
            }
            return newlines;
        }

        /// <summary>
        /// Сортировка по полю "дата"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] Sorted(string[] allLinesRecords)
        {

            if (allLinesRecords == null)
            {
                Console.WriteLine("В фале нет записей");
                return null;
            }

            DateTime[] dateArr = new DateTime[allLinesRecords.Length];

            for (int i = 0; i < dateArr.Length; i++)
            {
                string[] words = allLinesRecords[i].Split('#');

                if (words == null || words[0] == "" || words[0] == "\n")
                {
                    continue;
                }
                else dateArr[i] = Convert.ToDateTime(words[1]);
            }

            int numberSort;

            do
            {
                Console.WriteLine("\n Введите цифру :" +
                "\n 1 - для сортировке по возрастанию даты" +
                "\n 2 - для сортировки по убыванию даты");

                bool input = Int32.TryParse(Console.ReadLine(), out numberSort);

                if (input)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели не цифру");
                }
            }
            while (true);

            DateTime temp;

            if (numberSort == 1)
            {
                for (int i = 0; i < dateArr.Length - 1; i++)
                {
                    for (int j = i + 1; j < dateArr.Length; j++)
                    {
                        if (dateArr[i] > dateArr[j])
                        {
                            temp = dateArr[i];
                            dateArr[i] = dateArr[j];
                            dateArr[j] = temp;
                        }
                    }
                }
                Console.WriteLine("Записи отсортированы по возрастанию даты создания");
            }
            else if (numberSort == 2)
            {
                for (int i = 0; i < dateArr.Length - 1; i++)
                {
                    for (int j = i + 1; j < dateArr.Length; j++)
                    {
                        if (dateArr[i] < dateArr[j])
                        {
                            temp = dateArr[i];
                            dateArr[i] = dateArr[j];
                            dateArr[j] = temp;
                        }
                    }
                }
                Console.WriteLine("Записи отсортированы по убыванию даты создания");
            }

            string[] newarr = new string[allLinesRecords.Length];

            for (int i = 0; i < dateArr.Length; i++)
            {
                for (int j = 0; j < allLinesRecords.Length; j++)
                {
                    if (allLinesRecords[j].Contains(dateArr[i].ToString("dd.MM.yyyy hh:mm")))
                    {
                        newarr[i] = allLinesRecords[j];
                    }
                }
            }
            return newarr;
        }
    }
}
