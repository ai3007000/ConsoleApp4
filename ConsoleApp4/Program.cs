using System;
using System.Collections;
using System.Xml.Linq;

namespace ConsoleApp3.ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            ShowData(GetPurple());

        }

        static void ShowData((string FirstName, string LastName, int Age, string[] NamesOfPet, string[] FavoriteColores) User)
        {
            Console.WriteLine($"Имя: {User.FirstName}\nФамилия: {User.LastName}");
            Console.WriteLine($"Возраст: {User.Age}");

            if (User.NamesOfPet.Length > 0)
            {
                Console.WriteLine("Клички животных:");
                foreach (var item in User.NamesOfPet)
                {
                    Console.WriteLine(item);
                }
            }

            if (User.FavoriteColores.Length > 0)
            {
                Console.WriteLine("Мои любимые цвета:");
                foreach (var item in User.FavoriteColores)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static (string FirstName, string LastName, int Age, string[] NamesOfPet, string[] FavoriteColores) GetPurple()
        {
            (string FirstName, string LastName, int Age, bool hasPet, int numPet, string[] NamesOfPet, int NumFavoriteColor) User;

            while (true)
            {
                Console.WriteLine("Введите ваше имя:");
                User.FirstName = Console.ReadLine();

                CorrectString(User.FirstName, out bool isCorrect);

                if (isCorrect) break;
                else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
            }

            while (true)
            {
                Console.WriteLine("Введите вашу Фамилию:");
                User.LastName = Console.ReadLine();

                CorrectString(User.LastName, out bool isCorrect);

                if (isCorrect) break;
                else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
            }

            while (true)
            {
                Console.WriteLine("Введите ваш возраст:");
                bool isCorrect = int.TryParse(Console.ReadLine(), out User.Age);
                CorrectNumbers(User.Age, out bool isCorrectAge);

                if (isCorrectAge) break;
                else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
            }

            while (true)
            {
                Console.WriteLine("У вас есть питомцы? (Да/Нет):");
                string isHasPet = Console.ReadLine();
                CorrectString(isHasPet, out bool isCorrect);

                if (isHasPet == "Да") User.hasPet = true;
                else User.hasPet = false;

                if (isCorrect) break;
                else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
            }

            User.numPet = 0; // Заглушка для возврата данных
            User.NamesOfPet = new string[User.numPet]; // Заглушка для возврата данных
            if (User.hasPet)
            {
                while (true)
                {
                    Console.WriteLine("Введите количество ваших питомцев:");
                    int.TryParse(Console.ReadLine(), out User.numPet);

                    CorrectNumbers(User.numPet, out bool isCorrect);

                    if (isCorrect) break;
                    else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
                }
                NameOfPet(User.numPet, out User.NamesOfPet);
            }

            while (true)
            {
                Console.WriteLine("Введите количество ваших любимых цветов:");
                bool isCorrect = int.TryParse(Console.ReadLine(), out User.NumFavoriteColor);

                CorrectNumbers(User.NumFavoriteColor, out bool isCorrectFavoriteColores);
                if (isCorrectFavoriteColores) break;
                else Console.WriteLine("Некорректный ввод данных.\nПопробуйте снова.");
            }

            NumOfFavoriteColore(User.NumFavoriteColor, out string[] FavoriteColores);

            return (User.FirstName, User.LastName, User.Age, User.NamesOfPet, FavoriteColores);
        }

        static void NameOfPet(int numPet, out string[] NamesOfPet)
        {
            NamesOfPet = new string[numPet];
            for (int i = 0; i < numPet; i++)
            {
                Console.WriteLine($"Кличка питомца:");

                while (true)
                {
                    NamesOfPet[i] = Console.ReadLine();
                    CorrectString(NamesOfPet[i], out bool isCorrect);
                    if (isCorrect) break;
                }
            }
        }

        static void NumOfFavoriteColore(int numFavoriteColore, out string[] FavoriteColores)
        {
            FavoriteColores = new string[numFavoriteColore];

            for (int i = 0; i < numFavoriteColore; i++)
            {
                Console.WriteLine("Название вашего любимого цвета: ");
                FavoriteColores[i] = Console.ReadLine();
            }
        }

        static void CorrectString(string str, out bool isCorrect)
        {

            if (str == null) isCorrect = false;
            else if (int.TryParse(str, out int intnum)) isCorrect = false;
            else isCorrect = true;
        }

        static void CorrectNumbers(int number, out bool isCorrect)
        {
            if (number < 0) isCorrect = false;
            else isCorrect = true;
        }
    }
}