using System;

namespace SF5._6
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintData(InputData());
        }

        static (string firtsname, string lastname, int age, bool haveapet, int petscount, string[] petsnames, int favcolorscount, string[] favcolors) InputData ()
        {
            (string firtsname, string lastname, int age, bool haveapet, int petscount, string[] petsnames, int favcolorscount, string[] favcolors) user;

            Console.WriteLine("Введите имя!");
            user.firtsname = Console.ReadLine();

            Console.WriteLine("Введите фамилию!");
            user.lastname = Console.ReadLine();

            bool badsign = true;

            do
            {
                Console.WriteLine("Введите возраст!");
                user.age = CheckValue(Console.ReadLine());
                badsign = (user.age == 0);
            } while (badsign);


            Console.WriteLine("Есть питомец/питомцы? (Да/Нет)");
            user.haveapet = (Console.ReadLine() == "Да");

            user.petscount = 0;
            user.petsnames = new string[] { "" };

            if (user.haveapet)
            {
                do
                {
                    Console.WriteLine("Сколько зверей?");
                    user.petscount = CheckValue(Console.ReadLine());
                    badsign = (user.petscount == 0);
                } while (badsign);

                user.petsnames = GetPetsNames(user.petscount);
            }


            Console.WriteLine("Сколько любимых цветов?");
            user.favcolorscount = CheckValue(Console.ReadLine());

            if (user.favcolorscount == 0) // Никто не обещал, что будут вообще любимые цвета, и 0 тут - вариант корректного ответа.
            {
                user.favcolors = new string[] {""};
            }
            else
            {
                user.favcolors = GetFavColorsNames(user.favcolorscount);
            }

            return (user.firtsname, user.lastname, user.age, user.haveapet, user.petscount, user.petsnames, user.favcolorscount, user.favcolors);
        }

        static string[] GetPetsNames(int count)
        {
            string[] petsnames = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите имя зверя номер {0}:", i + 1);
                petsnames[i] = Console.ReadLine();
            }
            return petsnames;
        }

        static string[] GetFavColorsNames(int count)
        {
            string[] favcolorsnames = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите любимый цвет номер {0}:", i + 1);
                favcolorsnames[i] = Console.ReadLine();
            }

            return favcolorsnames;
        }

        static int CheckValue(string invalue)
        {
            int value;
            if (int.TryParse(invalue, out value))
            {
                value = int.Parse(invalue);
                if (value < 0)
                {
                    value = 0;
                }
            }
            return value;
        }

        static void PrintData((string firtsname, string lastname, int age, bool haveapet, int petscount, string[] petsnames, int favcolorscount, string[] favcolors) userdata)
        {
            Console.WriteLine("\n\nИмя: {0}", userdata.firtsname);
            Console.WriteLine("Фамилия: {0}", userdata.lastname);
            Console.WriteLine("Возраст: {0}", userdata.age);
            if (userdata.haveapet)
            {
                Console.WriteLine("Есть питомец/питомцы:");
                for (int i = 0; i < userdata.petscount; i++)
                {
                    Console.WriteLine("Зверь номер {0}: {1}", i + 1, userdata.petsnames[i]);
                }
            }
            else
            {
                Console.WriteLine("Нет питомца.");
            }
            Console.WriteLine("Любимых цветов: {0}", userdata.favcolorscount);
            if (userdata.favcolorscount > 0)
            {
                for (int i = 0; i < userdata.favcolorscount; i++)
                {
                    Console.WriteLine("Цвет номер {0}: {1}", i + 1, userdata.favcolors[i]);
                }
            }
        }
    }
}
