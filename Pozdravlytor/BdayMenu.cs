using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlytor
{
    public class BdayMenu
    {
        private List<Friend> bdayList;

        public void LoadData(string file)
        {
            bdayList = new List<Friend>();

            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    string name = data[0].Trim();
                    DateTime birthday = DateTime.Parse(data[1].Trim());

                    Friend friend = new Friend { Name = name, Birthday = birthday };
                    bdayList.Add(friend);
                }
            }
            else
            {
                Console.WriteLine($"Файл'{file}' не обнаружен, для создания добавьте ДР");
            }
        }

        public void SaveData(string file)
        {
            List<string> lines = new List<string>();

            foreach (Friend friend in bdayList)
            {
                string line = $"{friend.Name},{friend.Birthday.ToShortDateString()}";
                lines.Add(line);
            }

            File.WriteAllLines(file, lines);
        }

        public void AllBdays()
        {
            Console.WriteLine("Все ДР:");

            foreach (Friend friend in bdayList)
            {
                Console.WriteLine($"{friend.Name} - {friend.Birthday.ToShortDateString()}");
            }

            Console.WriteLine();
        }

        public void СomingBdays()
        {
            List<Friend> comingBdays = new List<Friend>();

            foreach (Friend friend in bdayList)
            {
                DateTime nextBday = new DateTime(DateTime.Today.Year, friend.Birthday.Month, friend.Birthday.Day);

                if (nextBday < DateTime.Today)
                {
                    nextBday = nextBday.AddYears(1);
                }

                TimeSpan remainingDays = nextBday - DateTime.Today;

                if (remainingDays.TotalDays <= 7)
                {
                    comingBdays.Add(friend);
                    comingBdays.Sort((x, y) => x.SortBdays().CompareTo(y.SortBdays()));
                }
            }

            Console.WriteLine("Ближайшие ДР:");

            if (comingBdays.Count == 0)
            {
                Console.WriteLine("Ближайших ДР нет, можно расслабиться.");
            }
            else
            {
                foreach (Friend friend in comingBdays)
                {
                    if (friend.SortBdays() == 366)
                    {
                        Console.WriteLine("                                                Сегодня ДР: \n");
                        Console.WriteLine($"                         !!! ДР сегодня - {friend.Name} - {friend.Birthday.ToShortDateString()} - сегодня ДР!!!");

                    }

                    else
                    {
                        Console.WriteLine($"{friend.Name} - {friend.Birthday.ToShortDateString()} - {friend.SortBdays()} дней до ДР");
                    }
                }
            }

            Console.WriteLine();
        }

        public void Lastbdays()
        {
            List<Friend> lastBdays = new List<Friend>();

            foreach (Friend friend in bdayList)
            {
                DateTime nextBday = new DateTime(DateTime.Today.Year, friend.Birthday.Month, friend.Birthday.Day);

                if (nextBday >= DateTime.Today)
                {
                    nextBday = nextBday.AddYears(-1);
                }

                TimeSpan remainingDays = DateTime.Today - nextBday;

                if (remainingDays.TotalDays < 7)
                {
                    lastBdays.Add(friend);
                    lastBdays.Sort((x, y) => x.SortBdaysLast().CompareTo(y.SortBdaysLast()));
                }
            }
            Console.WriteLine("Прошедшие ДР:");

            if (lastBdays.Count == 0)
            {
                Console.WriteLine("Прошедшие ДР были давно, можно не париться.");
            }
            else
            {
                foreach (Friend friend in lastBdays)
                {

                    Console.WriteLine($"{friend.Name} - {friend.Birthday.ToShortDateString()} - {friend.SortBdaysLast()} дней после ДР");

                }
            }

            Console.WriteLine();

        }




        public void AddBday()
        {
            Console.Write("Имя друга: ");
            string name = Console.ReadLine();

            Console.Write("Дата рождения (DD/MM/YYYY): ");
            DateTime birthday = DateTime.Parse(Console.ReadLine().Trim());

            Friend friend = new Friend { Name = name, Birthday = birthday };
            bdayList.Add(friend);

            Console.WriteLine("ДР сохраено.\n");
        }

        public void DeleteBday()
        {
            Console.Write("Введите имя для удаления: ");
            string name = Console.ReadLine();

            Friend DeleteFriend = null;

            foreach (Friend friend in bdayList)
            {
                if (friend.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    DeleteFriend = friend;
                    break;
                }
            }

            if (DeleteFriend != null)
            {
                bdayList.Remove(DeleteFriend);
                Console.WriteLine("ДР удалено, больше этого человека не поздравляем \n");
            }
            else
            {
                Console.WriteLine("ДР не найдено, посмотрите список ДР.\n");
            }
        }



        public void EditBday()
        {
            Console.Write("Введите имя для редактирования: ");
            string name = Console.ReadLine();

            Friend EditFriend = null;

            foreach (Friend friend in bdayList)
            {
                if (friend.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    EditFriend = friend;
                    break;
                }
            }

            if (EditFriend != null)
            {
                Console.Write("Введите новое имя, если ничего не ввести, имя останется прежним: ");
                string newName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    EditFriend.Name = newName;
                }

                Console.Write(" (Введите новую дату ДР ДД/ММ/ГГГГ, если ничего не ввести, дата останется прежней): ");
                string newBirthdayString = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(newBirthdayString))
                {
                    EditFriend.Birthday = DateTime.Parse(newBirthdayString);
                }

                Console.WriteLine("ДР изменено .\n");
            }
            else
            {
                Console.WriteLine("ДР не найдет, посмотрите список.\n");
            }

        }


    }
}