using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string LastName, int Age, bool Pet, int QuantityPet, string[] NamePet, int QuantityColors, string[] NameColors) User;

            User = UserInfo();

            Console.WriteLine($"Ваше имя: {User.Name}\n" +
                              $"Ваша фамилия: {User.LastName}\n" +
                              $"Ваш возраст: {User.Age}\n" +
                              $"У вас есть питомец: {User.Pet}\n" +
                              $"Количество ваших питомцев: {User.QuantityPet}\n" +
                              $"Количество любимых цветов: {User.QuantityColors}");

            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < User.NamePet.Length; i++)
            {
                Console.WriteLine($"{i + 1}.Имя питомца: {User.NamePet[i]}");
            }

            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < User.NameColors.Length; i++)
            {
                Console.WriteLine($"{i + 1}.Название цвета: {User.NameColors[i]}");
            }
        }

        private static (string Name, string LastName, int Age, bool Pet, int QuantityPet, string[] NamePet, int QuantityColors, string[] NameColors) UserInfo()
        {
            string text;

            text = "Введите имя: ";
            string name = ChekingInputString(text);

            text = "Введите фамилию: ";
            string lastname = ChekingInputString(text);

            text = "Введите возраст: ";
            int age = ChekingInputInteger(text);

            Console.WriteLine();

            (bool Pet, int QuantityPet, string[] NamePet) Pets = PresencePet();

            bool pet = Pets.Pet;
            int quantityPet = Pets.QuantityPet;
            string[] namePet = Pets.NamePet;

            Console.WriteLine();

            (int QuantityColors, string[] NameColors) FavoriteColor = FavoriteColors();

            int quantityColor = FavoriteColor.QuantityColors;
            string[] nameColor = FavoriteColor.NameColors;

            Console.Clear();

            return (name, lastname, age, pet, quantityPet, namePet, quantityColor, nameColor);
        }

        private static string ToUpperFirstLetter(string text)
        {
            char[] letter = text.ToCharArray();
            letter[0] = char.ToUpper(letter[0]);

            return new string(letter);
        }
        private static string ChekingInputString(string text)
        {
            string str;

            while (true)
            {
                Console.Write(text);
                str = Console.ReadLine().ToLower();

                if (int.TryParse(str, out int number))
                {
                    Console.WriteLine("\nОшибка. Некоректное значение!\n");
                }
                else
                {
                    break;
                }
            }

            str = ToUpperFirstLetter(str);

            return str;
        }
        private static int ChekingInputInteger(string text)
        {
            int number;
            string age;

            while (true)
            {
                Console.Write(text);
                age = Console.ReadLine();

                if (int.TryParse(age, out number))
                {
                    number = int.Parse(age);
                    if (number > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nОшибка. Некоректное значение!\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nОшибка. Некоректное значение!\n");
                }
            }

            return number;
        }
        private static (bool Pet, int QuantityPet, string[] NamePet) PresencePet()
        {
            bool pet = false;
            int quantityPet = 0;
            string[] namePet = { "" };

            Console.WriteLine("Есть ли у вас питомец?\n" +
                              "В ответе укажите 'Да' ли 'Нет'");

            while (true)
            {
                string pets = Console.ReadLine().ToLower();

                if (pets == "да" || pets == "yes")
                {
                    pet = true;

                    string text = "Здорово! Сколько у вас питомцев?\n" +
                                  "Введите количество питомцев: ";
                    quantityPet = ChekingInputInteger(text);
                    namePet = new string[quantityPet];

                    Console.WriteLine("Укажите их клички: ");
                    for (int i = 0; i < quantityPet; i++)
                    {
                        text = $"Кличка питомца {i + 1}: ";
                        namePet[i] = ChekingInputString(text);
                    }
                    break;
                }
                else if (pets == "нет" || pets == "no")
                {
                    Console.WriteLine("Здорово!");
                    pet = false;
                    break;
                }
                else
                {
                    Console.WriteLine("\nОшибка. Некоректное значение!\n");
                }
            }

            return (pet, quantityPet, namePet);
        }
        private static (int QuantityColors, string[] NameColors) FavoriteColors()
        {
            string text = "Введите количсетво любимых цветов: ";
            int quantityColors = ChekingInputInteger(text);

            string[] nameColors = new string[quantityColors];
            for (int i = 0; i < quantityColors; i++)
            {
                text = $"Ваш любимый цвет {i + 1}: ";
                nameColors[i] = ChekingInputString(text);
            }

            return (quantityColors, nameColors);
        }
    }
}
