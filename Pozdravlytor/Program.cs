using System;
using System.Collections.Generic;
using System.IO;

namespace Pozdravlytor

{
    class Program
    {
        static void Main(string[] args)
        {
            const string file = "Список ДР.txt";

            BdayMenu bdayMenu = new BdayMenu();
            bdayMenu.LoadData(file);

            Console.WriteLine("Дни рождения друзей\n");

            bdayMenu.СomingBdays();

            while (true)
            {
                Console.WriteLine("Список действий:");
                Console.WriteLine("1. Все ДР");
                Console.WriteLine("2. Ближайшие ДР");
                Console.WriteLine("3. Прошедшие ДР");
                Console.WriteLine("4. Добавить ДР");
                Console.WriteLine("5. Удалить ДР");
                Console.WriteLine("6. Изменить ДР");
                Console.WriteLine("7. Выйти\n");

                Console.Write("Выберите дйствие: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {

                    case "1":
                        bdayMenu.AllBdays();
                        break;
                    case "2":
                        bdayMenu.СomingBdays();
                        break;
                    case "3":
                        bdayMenu.Lastbdays();
                        break;
                    case "4":
                        bdayMenu.AddBday();
                        bdayMenu.SaveData(file);
                        break;
                    case "5":
                        bdayMenu.DeleteBday();
                        bdayMenu.SaveData(file);
                        break;
                    case "6":
                        bdayMenu.EditBday();
                        bdayMenu.SaveData(file);
                        break;
                    case "7":
                        bdayMenu.SaveData(file);
                        Console.WriteLine("Для выхода нажмите любую клавишу.");
                        return;

                    default:
                        Console.WriteLine("Такое действие не предусмотернно, смотрите список действий\n");
                        break;
                }
            }
        }
    }
}
