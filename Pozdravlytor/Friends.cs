using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlytor
{
    public class Friend
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public int SortBdays()
        {
            DateTime today = DateTime.Today;
            DateTime nextBday = new DateTime(today.Year, Birthday.Month, Birthday.Day);

            if (nextBday <= today)
                nextBday = nextBday.AddYears(1);

            return (nextBday - today).Days;


        }
        public int SortBdaysLast()
        {
            DateTime today = DateTime.Today;
            DateTime nextBday = new DateTime(today.Year, Birthday.Month, Birthday.Day);

            if (nextBday >= today)
                nextBday = nextBday.AddYears(-1);

            return (today - nextBday).Days;


        }
    }
}