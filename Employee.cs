using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    /// <summary>
    /// Структура "Сотрудник"
    /// </summary>
    public struct Employee
    {
        public string id;

        public string dateCreate;

        public string fullName;

        public string age;

        public string height;

        public string dateOfBirth;

        public string placeOfBirth;

        public Employee(string ID,
                        string FullName, string Age,
                        string Height, string DateOfBirth,
                        string PlaceOfBirth)
        {
            id = ID;

            dateCreate = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

            fullName = FullName;

            age = Age;

            height = Height;

            dateOfBirth = DateOfBirth;

            placeOfBirth = PlaceOfBirth;
        }
        public byte[] Record()
        {
            string record = id + "#" + dateCreate + "#" + fullName +
                "#" + age + "#" + height + "#" + dateOfBirth +
                "#" + placeOfBirth + "\r\n";

            byte[] array = System.Text.Encoding.Default.GetBytes(record);

            return array;
        }
    }
}
