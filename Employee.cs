using System;
using System.Text;

namespace HomeWork7_2
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
        public byte[] Record()
        {
            string record = id + "#" + dateCreate.ToString("dd.MM.yyyy hh:mm") + "#" + fullName +
                "#" + age + "#" + height + "#" + dateOfBirth.ToString("dd.MM.yyyy") +
                "#" + placeOfBirth + "\r\n";

            byte[] array = Encoding.Default.GetBytes(record);

            return array;
        }
    }
}
