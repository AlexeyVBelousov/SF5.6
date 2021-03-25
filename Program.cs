using System;

namespace SF5._6
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        static (string firtsname, string lastname, int age, bool haveapet, int petscount, string[] petsnames, int favcolorscount, string[] favcolors) InputData ()
        {
            Console.WriteLine("Введите имя!");
            string firstname = Console.ReadLine();

            Console.WriteLine("Введите фамилию!");
            string lastname = Console.ReadLine();

            Console.WriteLine("Введите возраст!");
            string inage = Console.ReadLine();

            int age;
            if (int.TryParse(inage, out age))
            {
                age = int.Parse(inage);
            }

            Console.WriteLine("Есть питомец/питомцы? (Да/Нет)");
            bool haveapet = (Console.ReadLine() == "Да");

            if (haveapet)
            {
                Console.WriteLine("Сколько зверей?");
                var inpetscount = Console.ReadLine();

                int petscount;
                if (int.TryParse(inpetscount, out petscount))
                {
                    petscount = int.Parse(inpetscount);
                    if (petscount <= 0)
                    {
                        petscount = 0;
                        haveapet = false;
                    }
                }

                if (petscount > 0)
                {
                    GetPetsNames(petscount);
                }


            }
        }

        static string[] GetPetsNames(int count)
        {
            string[] petsnames = new string[count-1];
            for (int i = 0; i < (count - 1); i++)
            {
                Console.WriteLine("Введите имя зверя номер {0}:", i + 1);
                petsnames[i] = Console.ReadLine();
            }

            return petsnames[];
        }
    }
}
